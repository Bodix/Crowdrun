using System;
using System.Collections;
using System.Linq;
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
            _crowd.Refill(1);

            _inputReader.Drag += ProcessInput;
            _inputReader.Drag += StartGameUnsubscribable;
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