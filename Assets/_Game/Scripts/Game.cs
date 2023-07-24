using System;
using System.Collections;
using System.Linq;
using Bodix.Crowdrun.UI;
using Evolutex.Evolunity.Components;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bodix.Crowdrun
{
    // TODO: Make as singleton and remove all direct references and crowd initialization. Or better use DI.
    // TODO: Refactor progress handling and level loading.
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private Level[] _levels;
        [SerializeField]
        private InputReader _inputReader;
        [SerializeField]
        private ProgressStorage _progressStorage;
        [SerializeField]
        private Crowd _crowd;
        [SerializeField]
        private GameObject _tutorialUi;
        [SerializeField]
        private GameObject _crowdCounterUi;
        [SerializeField]
        private FinishScreenUi _finishScreenUi;
        [SerializeField]
        private AudioSource _musicAudioSource;

        private Vector3 _crowdInitialPosition;
        private PlayerProgressData _currentProgress;

        public event Action<int> CoinsUpdated;

        public bool IsStarted { get; private set; }

        private int _coins;
        public int Coins
        {
            get => _coins;
            private set
            {
                _coins = value;
                CoinsUpdated?.Invoke(_coins);
            }
        }

        private void Awake()
        {
            _crowdInitialPosition = _crowd.transform.position;
            _inputReader.Drag += ProcessInput;
            _crowd.Initialize(this);

            LoadProgress();
            LoadLevel();
            ResetLevel();
        }

        public void FinishGame()
        {
            IsStarted = false;

            StartCoroutine(FinishGameCoroutine());
        }

        public void ResetLevel()
        {
            _inputReader.Drag += StartGameUnsubscribable;

            _crowd.transform.position = _crowdInitialPosition;
            _crowd.Refill(1, false);

            _musicAudioSource.Play();
            _crowdCounterUi.gameObject.SetActive(true);
            _tutorialUi.gameObject.SetActive(true);
        }

        private void LoadProgress()
        {
            _currentProgress = _progressStorage.LoadProgress();

            Coins = _currentProgress.Coins;
        }

        private void LoadLevel()
        {
            SceneManager.LoadScene(_levels[_currentProgress.Level].Scene, LoadSceneMode.Additive);
        }

        private AsyncOperation UnloadLevel()
        {
            return SceneManager.UnloadSceneAsync(_levels[_currentProgress.Level].Scene);
        }

        private IEnumerator FinishGameCoroutine()
        {
            _musicAudioSource.Stop();
        
            // Waiting for crowd running a little bit forward.
            yield return new WaitForSeconds(1f);

            _crowd.StopMovingAndDance();

            // Playing dance animation a little bit.
            yield return new WaitForSeconds(3f);

            foreach (Character character in _crowd.Characters.ToArray())
            {
                character.DestroyWithFx();
                Coins += 1;

                yield return new WaitForSeconds(0.1f);
            }

            _crowdCounterUi.gameObject.SetActive(false);

            yield return new WaitForSeconds(1f);

            UnloadLevel().completed += operation =>
            {
                // TODO: Make save progress earlier to prevent possible loss of progress data.
                _currentProgress.Coins = Coins;
                _currentProgress.Level = _currentProgress.Level = (_currentProgress.Level + 1) % _levels.Length;
                _progressStorage.SaveProgress(_currentProgress);

                LoadLevel();
            };

            _finishScreenUi.gameObject.SetActive(true);
        }

        private void ProcessInput(Vector2 input)
        {
            if (IsStarted)
                _crowd.Move(input.x);
        }

        private void StartGameUnsubscribable(Vector2 input)
        {
            _crowd.StartMoving();
            _tutorialUi.SetActive(false);

            IsStarted = true;

            _inputReader.Drag -= StartGameUnsubscribable;
        }
    }
}