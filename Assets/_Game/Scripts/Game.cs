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
        
        public bool IsStarted { get; private set; } 
        public int Coins { get; private set; }
        
        private void Awake()
        {
            _crowd.Refill(1);
            
            _inputReader.Drag += input => _crowd.Move(input.x);
            _inputReader.Drag += StartGameUnsubscribable;
        }

        private void StartGameUnsubscribable(Vector2 input)
        {
            _crowd.StartMoving();
            _tutorialUi.SetActive(false);

            IsStarted = true;

            _inputReader.Drag -= StartGameUnsubscribable;
        }

        private void FinishGame()
        {
            IsStarted = false;
            
        }
    }
}