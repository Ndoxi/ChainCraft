using ChainCraft.Core.Input;
using ChainCraft.Infrastracture;
using UnityEngine;

namespace ChainCraft.Core.Gameplay
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerMovement _movement;
        private IInputChanel _input;

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
        }

        private void Start()
        {
            _input = ServiceLocator.Resolve<IInputChanel>();
        }

        private void Update()
        {
            _movement.SetDirection(_input.moveInput);
        }
    }
}
