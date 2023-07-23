using System;
using Evolutex.Evolunity.Components;
using Evolutex.Evolunity.Utilities;
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

            Repeat.EverySeconds(1, () => Coins += 1);
        }

        public void FinishGame()
        {
            IsStarted = false;

            Delay.ForSeconds(1f, () => _crowd.StopMovingAndDance());
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