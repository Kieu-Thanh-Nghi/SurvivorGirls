using UnityEngine;
public class EnemyAdapter : MonoBehaviour, ITargetChangable, ISpeedChangable, IMoveFreezing
{
    [SerializeField] internal Transform allBody;
    [SerializeField] internal Enemy enemy;

    public void ResetSpeed() => enemy.ResetSpeed();

    public void ResetMoveMechanic()
    {
        enemy.moveManagement.ResetMoveMechanic();
    }

    public void ResetTarget()
    {
        enemy.Target = GamePlayCtrler.Instance.Player;
        enemy.EnemyMove();
    }

    public void SetIsMoveFreeze(bool isFreeze)
    {
        enemy.SetStopMoving(isFreeze);
    }

    public void SetTarget(Transform newTarget)
    {
        enemy.Target = newTarget;
        enemy.EnemyMove();
    }

    public void SpeedMultiplyWith(float amount)
    {
        enemy.SpeedMultiply(amount);
    }
}
