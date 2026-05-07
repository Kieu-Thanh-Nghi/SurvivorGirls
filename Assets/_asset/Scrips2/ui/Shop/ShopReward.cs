using UnityEngine;

public abstract class ShopReward<T> : MonoBehaviour
{
    public abstract T GetReward();
}