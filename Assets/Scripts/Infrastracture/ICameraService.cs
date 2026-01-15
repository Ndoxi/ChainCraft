using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public interface ICameraService
    {
        Camera mainCamera { get; }
        Camera currentCamera { get; }
    }
}
