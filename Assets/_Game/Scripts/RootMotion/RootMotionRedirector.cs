using _Game.Scripts.RootMotion;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RootMotionRedirector : MonoBehaviour
{
    private Animator _animator;
    private IRootMotionReceiver _receiver;

    private bool? _initialApplyRootMotion;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorMove()
    {
        _receiver.MoveByRootMotion(_animator.deltaPosition, _animator.deltaRotation);
    }

    private void OnDestroy()
    {
        if (_initialApplyRootMotion.HasValue)
            _animator.applyRootMotion = _initialApplyRootMotion.Value;
    }

    public RootMotionRedirector Initialize(IRootMotionReceiver receiver, bool forceApplyRootMotion = true)
    {
        _receiver = receiver;

        if (forceApplyRootMotion)
        {
            _initialApplyRootMotion = _animator.applyRootMotion;
            _animator.applyRootMotion = true;
        }

        return this;
    }
}