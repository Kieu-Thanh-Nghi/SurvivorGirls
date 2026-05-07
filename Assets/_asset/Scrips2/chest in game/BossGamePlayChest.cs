using System.Collections.Generic;
using UnityEngine;

public class BossGamePlayChest : MonoBehaviour, IDamageable
{
    [SerializeField] List<PickableItem> pickableItems;

    public void TakeDamage(int dameAmount, DamageType type)
    {
        foreach (var item in pickableItems)
        {
            item.SpawnThisOut();
        }
        Destroy(gameObject);
    }

    public void SpawnThisChest()
    {
        var theLand = GamePlayCtrler.Instance.mapManager.GetSquareOfAPosion(transform.position);
        transform.SetParent(theLand, true);
        transform.localScale = Vector3.one;
        gameObject.SetActive(true);
    }
}