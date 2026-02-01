using DG.Tweening;
using System;
using UnityEngine;

namespace UI
{
    public class Disclaimer : GameWindow
    {
        [SerializeField] private RectTransform text;

        [Header("Animation")]
        [SerializeField] private float scaleDuration;
        [SerializeField] private float animationDuration;

        public Action OnOpenDisclaimer;
        public Action OnCloseDisclaimer;

        public override void OpenWindow()
        {
            gameObject.SetActive(true);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(text.DOScale(Vector3.one, scaleDuration))
                    .AppendInterval(animationDuration)
                    .AppendCallback(() => OnOpenDisclaimer?.Invoke());
            
        }
        public override void CloseWindow()
        {
            gameObject.SetActive(false);
            OnCloseDisclaimer?.Invoke();
        }

    }
}
