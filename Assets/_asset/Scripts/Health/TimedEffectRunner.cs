using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimedEffectRunner
{
    internal float totalTime = 5f;
    internal float interval = 0.5f;
    internal float elapsed;
    internal bool isInfinite, isStop;

    public IEnumerator RunEff(UnityAction effect, UnityAction onComplete = null, UnityAction onBegin = null)
    {
        elapsed = 0;
        float timer = 0f;
        isStop = false;
        onBegin?.Invoke();
        while (elapsed < totalTime || isInfinite)
        {
            Debug.Log("e" + elapsed);
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
    public IEnumerator ActiveEff(UnityAction Starteffect, UnityAction EndEff)
    {
        elapsed = 0;
        isStop = false;
        Starteffect?.Invoke();
        while (elapsed < totalTime || isInfinite)
        {
            if (isStop)
            {
                EndEff?.Invoke();
                yield break;
            }
            elapsed += Time.deltaTime;
            yield return null;
        }
        EndEff?.Invoke();
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
    public IEnumerator RunCoolDown(IHasCoolDown hasCoolDown)
    {
        counting = 0;
        while (true)
        {
            counting += Time.deltaTime;
            if (counting >= hasCoolDown.GetCoolDown())
            {
                yield break;
            }
            yield return null;
        }
    }
}

public interface IHasCoolDown
{
    public float GetCoolDown();
}