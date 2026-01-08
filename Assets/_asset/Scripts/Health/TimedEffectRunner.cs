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

[System.Serializable]
public class CoolDownSystem
{
    float counting;

    public IEnumerator RunEffInCoolDown(UnityAction effect, IHasCoolDown hasCoolDown, bool isRunimmediately = true)
    {
        if (isRunimmediately)
        {
            counting = hasCoolDown.GetCoolDown();
        }
        else
        {
            counting = 0;
        }
        while (true)
        {
            counting += Time.deltaTime;
            if (counting >= hasCoolDown.GetCoolDown())
            {
                effect?.Invoke();
                counting = 0;
            }
            yield return null;
        }
    }
}

public interface IHasCoolDown
{
    public float GetCoolDown();
}