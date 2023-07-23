using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RedirectRootMotionToCrowd : MonoBehaviour
{
    private Animator _animator;
    private Crowd _crowd;

    private bool _initialIsApplyRootMotion;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _initialIsApplyRootMotion = _animator.applyRootMotion;
        _animator.applyRootMotion = true;
    }

    private void OnAnimatorMove()
    {
        _crowd.transform.Translate(new Vector3(0, 0, _animator.deltaPosition.z));
    }

    private void OnDestroy()
    {
        _animator.applyRootMotion = _initialIsApplyRootMotion;
    }

    public RedirectRootMotionToCrowd Initialize(Crowd crowd)
    {
        _crowd = crowd;

        return this;
    }
}
