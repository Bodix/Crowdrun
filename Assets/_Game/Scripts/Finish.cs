using UnityEngine;

namespace Bodix.Crowdrun
{
    public class Finish : MonoBehaviour, ICrowdTrigger
    {
        [SerializeField]
        private Game _game;

        public void Enter(Crowd crowd)
        {
            _game.FinishGame();
        }
    }
}