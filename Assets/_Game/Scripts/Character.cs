using UnityEngine;

namespace Bodix.Crowdrun
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private static readonly int SpeedParam = Animator.StringToHash("Speed");
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
    }
}