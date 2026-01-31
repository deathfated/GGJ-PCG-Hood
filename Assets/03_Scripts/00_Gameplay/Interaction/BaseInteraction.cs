using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseInteraction : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        TriggerEnter(other);
    }

    public void OnTriggerExit(Collider other)
    {
        TriggerExit(other);
    }

    public abstract void TriggerEnter(Collider other);

    public virtual void TriggerExit(Collider other)
    {

    }

    public IEnumerator Fade(CanvasGroup canvas, float from, float to, float fadeduration = 0.5f, UnityAction onComplete = null)
    {
        float time = 0f;
        canvas.alpha = from;

        while (time < fadeduration)
        {
            time += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(from, to, time / fadeduration);
            yield return null;
        }

        onComplete?.Invoke();

        canvas.alpha = to;
    }
}
