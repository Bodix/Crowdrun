using System;
using System.Collections;
using System.Linq;
using Bodix.Crowdrun.UI;
using Evolutex.Evolunity.Components;
using UnityEngine;

namespace Bodix.Crowdrun
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private InputReader _inputReader;
        [SerializeField]
        private Crowd _crowd;
        [SerializeField]
        private GameObject _tutorialUi;
        [SerializeField]
        private GameObject _crowdCounterUi;
        [SerializeField]
        private FinishScreenUi _finishScreenUi;

        private Vector3 _crowdInitialPosition;

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
            
            ResetLevel();
        }

        public void FinishGame()
        {
            IsStarted = false;

            StartCoroutine(FinishGameCoroutine());
        }

        private IEnumerator FinishGameCoroutine()
        {
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

        public void ResetLevel()
        {
            _inputReader.Drag += StartGameUnsubscribable;

            _crowd.transform.position = _crowdInitialPosition;
            _crowd.Refill(1, false);

            _crowdCounterUi.gameObject.SetActive(true);
            _tutorialUi.gameObject.SetActive(true);
        }
    }
}