using UnityEngine;
using UnityEngine.Events;

public class ProgressSetter : MonoBehaviour
{
    [SerializeField] UnityEvent OnProgressNotFull, OnProgressFull;
    [SerializeField] UnityEvent<int, int> OnProgressChange;
    public void SetProgress(int havingAmount, int neededAmount)
    {
        OnProgressChange.Invoke(havingAmount, neededAmount);
        if (havingAmount < neededAmount)
        {
            OnProgressNotFull?.Invoke();
        }
        else
        {
            OnProgressFull?.Invoke();
        }
    }
}