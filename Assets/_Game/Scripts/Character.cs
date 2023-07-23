using UnityEngine;

namespace _Game.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private static readonly int SpeedParam = Animator.StringToHash("Speed");

        public Character Initialize(float forwardSpeed)
        {
            _animator.SetFloat(SpeedParam, forwardSpeed);

            return this;
        }
    }
}