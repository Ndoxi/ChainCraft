using UnityEngine;

namespace ChainCraft.Core.Gameplay
{
    public class GameplayWeaver : MonoBehaviour
    {
        [Header("Player and Camera")]
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private CameraFollow _cameraFollow;

        private void Start()
        {
            CreatePlayerAndFocusCamera();
        }

        private void CreatePlayerAndFocusCamera()
        {
            var player = Instantiate(_playerPrefab);
            _cameraFollow.target = player.transform;
        }
    }
}
