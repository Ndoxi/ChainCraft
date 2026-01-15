using Unity.VisualScripting;
using UnityEngine;

namespace ChainCraft.Core.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        private Rigidbody _rigidbody;
        private Vector2 _direction;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void FixedUpdate()
        {
            Vector2 movementVector2D = _speed * _direction;
            var movementVector = new Vector3(movementVector2D.x, 0f, movementVector2D.y);
            _rigidbody.AddForce(movementVector - _rigidbody.velocity, ForceMode.VelocityChange);

            if (_direction.sqrMagnitude > 0.001f)
            {
                var targetRotation = Quaternion.LookRotation(movementVector);
                _rigidbody.rotation = targetRotation;
            }

            _direction = Vector2.zero;
        }
    }
}
