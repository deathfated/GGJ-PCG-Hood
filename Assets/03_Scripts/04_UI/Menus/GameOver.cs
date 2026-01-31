using DG.Tweening;
using UnityEngine;
namespace UI
{
    public class GameOver : GameWindow
    {
        [SerializeField] private RectTransform gameOverText;
        [SerializeField] private GameObject buttonGroup;

        private readonly float textScaleDuration = 0.5f;
        public override void OpenWindow()
        {
            Time.timeScale = 0;

            gameObject.SetActive(true);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(gameOverText.DOScale(Vector3.one, textScaleDuration))
                    .AppendCallback(() => buttonGroup.gameObject.SetActive(true));
        }
        public override void CloseWindow()
        {
            Time.timeScale = 1;
        }
    }

}