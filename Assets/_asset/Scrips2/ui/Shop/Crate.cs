using UnityEngine;
using UnityEngine.Events;

public class Crate<T> : MonoBehaviour
{
    [SerializeField] internal UnityEvent<T> DoWhenAchive;
    [SerializeField] ShopReward<T> theReward;

    public virtual void AchiveReward()
    {
        T theReward = GetTheReward();
        DoWhenAchive?.Invoke(theReward);
    }

    public T GetTheReward() => theReward.GetReward();
}
