using ChainCraft.Infrastracture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChainCraft.Core.Input
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private Joystick _virtualJoystick;
        private IInputChanel _inputChanel;

        private void Start()
        {
            _inputChanel = ServiceLocator.Resolve<IInputChanel>();
        }

        private void Update()
        {
            var input = new Vector2(_virtualJoystick.Horizontal, _virtualJoystick.Vertical);
            _inputChanel.moveInput = input;
        }
    }
}
