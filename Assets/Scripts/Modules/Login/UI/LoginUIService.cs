using System.Threading;
using Cysharp.Threading.Tasks;
using MiningFarm.Core.Base;
using TMPro;
using UnityEngine;

namespace MiningFarm.Login
{
    public class LoginUIService : UIServiceBase
    {
        [SerializeField] private TMP_Text _loadingText;
        
        private readonly CancellationTokenSource _cancellationToken = new();
        
        public async UniTask RunLoading(float duration, System.Action onCompleted = null)
        {
            await AnimateProgress(duration, _cancellationToken.Token);
            onCompleted?.Invoke();
        }

        private void OnDestroy()
        {
            _cancellationToken.Cancel();
            _cancellationToken.Dispose();
        }
        
        private async UniTask AnimateProgress(float duration, CancellationToken token, float from = 0f, float to = 100f)
        {
            var elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                token.ThrowIfCancellationRequested();

                elapsedTime += Time.deltaTime;
                var normalized = Mathf.Clamp01(elapsedTime / duration);
                var progress = Mathf.Lerp(from, to, normalized);

                UpdatePanelProgress(progress);
                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }
        }

        private void UpdatePanelProgress(float progress)
        {
            var clampedProgress = Mathf.Clamp(Mathf.Floor(progress), 0, 100);
            _loadingText.text = $"LOADING {clampedProgress}%";
        }
    }
}