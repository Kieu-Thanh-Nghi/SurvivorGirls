using UnityEngine;
public class EnemyAdapter : MonoBehaviour, ITargetChangable, ISpeedChangable, IMoveFreezing
{
    [SerializeField] Enemy enemy;

    public void ResetSpeed() => enemy.ResetSpeed();

    public void ResetTarget()
    {
        enemy.target = GamePlayCtrler.Instance.Player;
        enemy.SetEnemyDestination();
    }

    public void SetIsMoveFreeze(bool isFreeze)
    {
        enemy.SetStopMoving(isFreeze);
    }

    public void SetTarget(Transform newTarget)
    {
        enemy.target = newTarget;
        enemy.SetEnemyDestination();
    }

    public void SpeedMultiplyWith(float amount)
    {
        float newSpeed = enemy.enemyData.moveSpeed * amount;
        enemy.SetSpeed(newSpeed);
    }
}

public class EffectHandler : MonoBehaviour
{

}

public class Effect : MonoBehaviour
{
    protected TimedEffectRunner effectRunner = new();
    [SerializeField] protected float totalTime = 5;
    public void RefressEff()
    {
        effectRunner.elapsed = 0;
    }
    public void SetInfinite(bool isInfinte)
    {
        effectRunner.isInfinite = isInfinte;
    }    
    public void StopEff(bool isStop)
    {
        effectRunner.isStop = isStop;
    }
}


