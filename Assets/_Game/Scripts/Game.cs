using Evolutex.Evolunity.Components;
using UnityEngine;

namespace Bodix.Crowdrun
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private InputReader _inputReader;
        [SerializeField]
        private Player _player;
        [SerializeField]
        private GameObject _tutorialUi;
        
        public bool IsStarted { get; private set; } 
        
        private void Awake()
        {
            _inputReader.Drag += StartGame;
        }

        private void StartGame(Vector2 obj)
        {
            _player.StartGame();
            _tutorialUi.SetActive(false);

            IsStarted = true;

            _inputReader.Drag -= StartGame;
        }
    }
}