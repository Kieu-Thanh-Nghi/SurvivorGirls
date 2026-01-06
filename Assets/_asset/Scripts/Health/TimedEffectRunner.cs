using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimedEffectRunner
{
    public float totalTime = 5f;
    public float interval = 0.5f;
    public float elapsed;
    public bool isInfinite, isStop;

    public IEnumerator RunEff(UnityAction effect, UnityAction onComplete = null)
    {
        elapsed = 0;
        float timer = 0f;
        isStop = false;

        while (elapsed < totalTime || isInfinite)
        {
            if (isStop)
            {
                onComplete?.Invoke();
                yield break;
            }
            elapsed += Time.deltaTime;
            timer += Time.deltaTime;

            if (timer >= interval)
            {
                timer -= interval;
                effect?.Invoke();
            }

            yield return null;
        }
        onComplete?.Invoke();
    }
}