using ChainCraft.Core.Production;
using System.Collections;
using TMPro;
using UnityEngine;

namespace ChainCraft.Core.Gameplay
{
    public class ProducerUI : MonoBehaviour
    {
        [SerializeField] private ProgressDisplayUI _progressDisplay;
        [SerializeField] private TextMeshProUGUI _reasonText;

        private ProducerModel _producer;
        private Coroutine _updateCoroutine;

        public void Init(ProducerModel producer)
        {
            _producer = producer;

            _producer.productionResumed += ShowProgress;
            _producer.productionStoped += ShowStopReason;
        }

        private void OnDestroy()
        {
            _producer.productionResumed -= ShowProgress;
            _producer.productionStoped -= ShowStopReason;
        }

        private void ShowProgress()
        {
            _progressDisplay.gameObject.SetActive(true);
            _reasonText.gameObject.SetActive(false);

            if (_updateCoroutine != null)
            {
                StopCoroutine(_updateCoroutine);
                _updateCoroutine = null;
            }
            _updateCoroutine = StartCoroutine(UpdateProgressDisplayCorutine());
        }

        private void ShowStopReason(ProducerModel.ProductionStopReason stopReason)
        {
            if (_updateCoroutine != null)
            {
                StopCoroutine(_updateCoroutine);
                _updateCoroutine = null;
            }

            _progressDisplay.gameObject.SetActive(false);
            _reasonText.gameObject.SetActive(true);

            _reasonText.text = GetReasonText(stopReason);
        }

        private IEnumerator UpdateProgressDisplayCorutine()
        {
            while (_producer.productionProgress < 1f) 
            {
                _progressDisplay.SetProgress(_producer.productionProgress);
                yield return null;
            }

            _progressDisplay.SetProgress(1f);
        }

        private string GetReasonText(ProducerModel.ProductionStopReason stopReason)
        {
            return stopReason switch
            {
                ProducerModel.ProductionStopReason.NoInput => "No input!",
                ProducerModel.ProductionStopReason.OutputFull => "Output full!",
                _ => throw new System.ArgumentException($"Invalid stop reason! StopReason:{stopReason}"),
            };
        }
    }
}
