using BattleJourney.Gameplay;
using UnityEngine;

namespace Bodix.Crowdrun
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private SpecialFx _destroyFx;

        private static readonly int SpeedParam = Animator.StringToHash("Speed");
        private static readonly int StopMovingParam = Animator.StringToHash("Stop Moving");
        private static readonly int DanceParam = Animator.StringToHash("Dance");
        private static readonly int RunState = Animator.StringToHash("Run");

        public Character Initialize(float forwardSpeed, bool isMoving)
        {
            // TODO: Add noise to run animation.
            _animator.SetFloat(SpeedParam, forwardSpeed);
            if (isMoving)
                StartMoving();

            return this;
        }

        public void StartMoving()
        {
            _animator.Play(RunState);
        }

        public void StopMovingAndDance()
        {
            _animator.SetTrigger(StopMovingParam);
            _animator.SetTrigger(DanceParam);
        }

        public void DestroyAnimated()
        {
            _destroyFx.Play();
            Destroy(gameObject);
        }
    }
}