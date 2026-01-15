using UnityEngine;
using UnityEngine.UI;

namespace ChainCraft.Core.Gameplay
{
    public class ProgressDisplayUI : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private void Awake()
        {
            SetProgress(0f);
        }

        public void SetProgress(float progress)
        {
            _image.fillAmount = progress;
        }
    }
}
