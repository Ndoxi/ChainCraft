using ChainCraft.Infrastracture;
using UnityEngine;

namespace ChainCraft.Core.Production
{
    public class WorldUI : MonoBehaviour
    {
        private WorldUIMarker _marker;
        private ICameraService _cameraService;

        public void Init(WorldUIMarker marker)
        {
            _marker = marker;
            _cameraService = ServiceLocator.Resolve<ICameraService>();
        }

        private void LateUpdate()
        {
            if (_marker == null)
                return;

            Vector3 screenPos = _cameraService.mainCamera.WorldToScreenPoint(_marker.markerPosition);
            transform.position = screenPos;
        }
    }
}