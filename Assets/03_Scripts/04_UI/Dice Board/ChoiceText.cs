using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ChoiceText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI hiddenChoice;
        [SerializeField] private TextMeshProUGUI revealedChoice;
        [SerializeField] private RectTransform transition; 

        public void ShowChoice()
        {
            hiddenChoice.gameObject.SetActive(true);
            revealedChoice.gameObject.SetActive(false);
        }
        public void RevealChoice(string text)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.AppendCallback(() =>
            {
                hiddenChoice.gameObject.SetActive(false);
                transition.gameObject.SetActive(true);
            })
            .Join(transition.DOScaleX(1, 0.2f))
            .AppendCallback(() => {
                revealedChoice.gameObject.SetActive(true);
                revealedChoice.text = text;
                transition.gameObject.SetActive(false);
            });
        }
    }
}
