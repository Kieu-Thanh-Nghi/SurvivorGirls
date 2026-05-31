using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] internal float AttackCountdown;
    [SerializeField] internal PlayerAttack playerAttack;
    float counting;

    protected virtual void Start()
    {
        counting = 0;
    }
    protected virtual void Update()
    {
        if (playerAttack.IsDone) counting += Time.deltaTime;

        if(counting >= AttackCountdown)
        {
            counting = 0;
            AttackLoop();
        }
    }

    public virtual void AttackLoop()
    {
        DoAttack();
    }

    public virtual void DoAttack()
    {
        playerAttack.DoAttack();
    }
}
