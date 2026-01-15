using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public class CameraService : ICameraService
    {
        public Camera mainCamera => Camera.main;
        public Camera currentCamera => Camera.current;
    }
}
