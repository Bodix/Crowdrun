using Evolutex.Evolunity.Components;
using Evolutex.Evolunity.Extensions;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private InputReader _inputReader;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _directionalSpeed = 1;
    [SerializeField]
    private float _speed = 3;
    
    private static readonly int DirectionParam = Animator.StringToHash("Direction");
    private static readonly int SpeedParam = Animator.StringToHash("Speed");
    private float _direction = 0;

    private void Awake()
    {
        _inputReader.Drag += input => Move(input.x);
        
        _animator.SetFloat(SpeedParam, _speed);
    }

    public void Move(float input)
    {
        _direction += input * _directionalSpeed * 0.03f;
        
        
        _animator.SetFloat(DirectionParam, _direction += input * _directionalSpeed * 0.03f);
        transform.position = transform.position.AddX(input * _directionalSpeed * 0.02f);
    }
}
