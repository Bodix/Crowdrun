using UnityEngine;

namespace Bodix.Crowdrun
{
    public class Finish : MonoBehaviour, ICrowdTrigger
    {
        [SerializeField]
        private SpecialFx _winFx;

        public void Enter(Crowd crowd)
        {
            _winFx.Play().StopAfter(_winFx.AudioClipDuration);
            crowd.Game.FinishGame();
        }
    }
}