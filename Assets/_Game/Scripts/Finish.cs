using UnityEngine;

namespace Bodix.Crowdrun
{
    public class Finish : MonoBehaviour, ICrowdTrigger
    {
        [SerializeField]
        private Game _game;

        public void Enter(Crowd crowd)
        {
            throw new System.NotImplementedException();
        }
    }
}