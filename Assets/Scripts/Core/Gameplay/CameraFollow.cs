using UnityEngine;

namespace ChainCraft.Core.Gameplay
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new(0, 5, -7);
        public float smoothSpeed = 10f;

        private void LateUpdate()
        {
            if (target == null)
                return;

            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
