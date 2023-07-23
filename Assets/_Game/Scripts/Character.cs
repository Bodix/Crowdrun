using UnityEngine;

namespace _Game.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private static readonly int SpeedParam = Animator.StringToHash("Speed");
        private static readonly int IsMovingParam = Animator.StringToHash("IsMoving");

        public Character Initialize(float forwardSpeed)
        {
            _animator.SetFloat(SpeedParam, forwardSpeed);

            return this;
        }

        public void StartMoving()
        {
            _animator.SetTrigger(IsMovingParam);
        }
    }
}