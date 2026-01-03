using UnityEngine;

public class EnemyAdapter : MonoBehaviour, ITargetChangable
{
    [SerializeField] Enemy enemy;
    public void ResetTarget()
    {
        enemy.target = GamePlayCtrler.Instance.Player;
        enemy.SetEnemyDestination();
    }

    public void SetTarget(Transform newTarget)
    {
        enemy.target = newTarget;
        enemy.SetEnemyDestination();
    }
}

public class EffectHandler : MonoBehaviour
{

}

public class Effect : MonoBehaviour
{

}

public class ElectricEff : Effect
{
    internal float ActiveTime, CoolDown;

    private void OnEnable()
    {
        
    }
}