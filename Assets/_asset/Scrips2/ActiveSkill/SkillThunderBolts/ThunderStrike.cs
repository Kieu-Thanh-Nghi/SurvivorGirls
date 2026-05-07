using Lean.Pool;
using UnityEngine;

public class ThunderStrike : ElectStatusGiver
{
    [SerializeField] AudioSource lightningSound;
    internal override int Damage
     => Mathf.CeilToInt(damage * (1 + PlayerDataManager.Instance.ElementBoost));
    internal override float SpeedDecreaseAmount
        => speedDecreaseAmount * (1 + PlayerDataManager.Instance.ElementBoost);
    private void OnEnable()
    {
        lightningSound.Play();
        LeanPool.Despawn(gameObject, 1);
    }
}
