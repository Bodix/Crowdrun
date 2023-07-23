using UnityEngine;

namespace Bodix.Crowdrun.RootMotion
{
    public interface IRootMotionReceiver
    {
        public void MoveByRootMotion(Vector3 deltaPosition, Quaternion deltaRotation);
    }
}