using DG.Tweening;
using Psalmhaven;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

namespace UI 
{
    public class MainMenu : GameWindow
    {
        [SerializeField] private RectTransform title;
        [SerializeField] private RectTransform subtitle;
        [SerializeField] private RectTransform startText;
        [SerializeField] private Image background;

        [Header("Animation")]
        [SerializeField] private float backgroundFadeDuration = 1f;
        [SerializeField] private float titleMovePos;
        [SerializeField] private float titleMoveDuration = 0.5f;

        public override void OpenWindow()
        {
           gameObject.SetActive(true);

            Sequence sequence = DOTween.Sequence();
            sequence.Append(background.DOFade(1, backgroundFadeDuration))
                    .Append(title.DOAnchorPosX(titleMovePos, titleMoveDuration).SetEase(Ease.InQuart))
                    .AppendCallback(() => {
                        subtitle.gameObject.SetActive(true);
                        startText.gameObject.SetActive(true);
                     });
        }
        public override void CloseWindow()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(background.DOFade(0, backgroundFadeDuration))
                    .AppendCallback(() => gameObject.SetActive(false));
        }
    }
}