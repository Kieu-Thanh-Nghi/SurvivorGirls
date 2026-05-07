using Lean.Pool;
using System.Collections.Generic;
using UnityEngine;

public class GameplayChest : MonoBehaviour, IDamageable
{
    [SerializeField] List<AboutPickableItem> pickableItems;

    public void TakeDamage(int dameAmount, DamageType type)
    {
        var randomPick = Random.Range(0, 101);
        int k = 0;
        foreach (var item in pickableItems)
        {
            k += item.spawnPercent;
            if (randomPick < k)
            {
                item.pickableItem.SpawnThisOut();
                break;
            }
        }
        LeanPool.Despawn(gameObject);
    }
}

[System.Serializable]
public class AboutPickableItem
{
    [SerializeField] internal PickableItem pickableItem;
    [SerializeField] internal int spawnPercent;
}
