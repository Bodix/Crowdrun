using UnityEngine;

namespace _Game.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private CharacterController _controller;

        private static readonly int DirectionParam = Animator.StringToHash("Direction");
        private static readonly int SpeedParam = Animator.StringToHash("Speed");

        private float _forwardSpeed = 1;
        private float _directionalSpeed = 1;
        private float _direction = 0;

        public Character Initialize(float forwardSpeed, float directionalSpeed)
        {
            _forwardSpeed = forwardSpeed;
            _directionalSpeed = directionalSpeed;

            _animator.SetFloat(SpeedParam, _forwardSpeed);

            return this;
        }

        public void Move(float input)
        {
            _direction += input * _directionalSpeed * 0.03f;
            _animator.SetFloat(DirectionParam, _direction += input * _directionalSpeed * 0.03f);

            _controller.SimpleMove(new Vector3(input, 0, 0));
        }
    }
}