using Evolutex.Evolunity.Components;
using UnityEngine;

namespace Bodix.Crowdrun
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private InputReader _inputReader;
        [SerializeField]
        private Crowd _crowd;

        private int _coins;
        private bool _isStarted;

        private void Awake()
        {
            _inputReader.Drag += input => _crowd.Move(input.x);

            _crowd.Refill(1);
        }

        public void StartGame()
        {
            _crowd.StartMoving();
        }
    }
}