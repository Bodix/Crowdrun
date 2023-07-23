using UnityEngine;

namespace _Game.Scripts.RootMotion
{
    public interface IRootMotionReceiver
    {
        public void MoveByRootMotion(Vector3 deltaPosition, Quaternion deltaRotation);
    }
}