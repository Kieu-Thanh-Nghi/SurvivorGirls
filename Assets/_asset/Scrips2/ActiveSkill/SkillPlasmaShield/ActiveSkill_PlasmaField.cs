using System.Collections;
using UnityEngine;

public class ActiveSkill_PlasmaField : MonoBehaviour, IHasCoolDown
{
    [SerializeField] SphereCollider coll;
    [SerializeField] float totalTime = 6f;
    [SerializeField] float interval = 1;
    [SerializeField] float baseCoolDown = 4;
    [SerializeField] LayerMask layerMask;
    [SerializeField] internal int damage = 1;
    CoolDownSystem coolDownSystem = new();
    TimedEffectRunner timedEffectRunner = new();
    float worldRadius;
    public float GetCoolDown()
    {
        return baseCoolDown * PlayerParaScale.Instance._coolDown;
    }
    
    private void Start()
    {
        CalculateRadius();
        timedEffectRunner.totalTime = totalTime;
        timedEffectRunner.interval = interval;

        StartCoroutine(RunSkill());
    }
    internal void CalculateRadius()
    {
        var collLossyScale = coll.transform.lossyScale;
        worldRadius =
        coll.radius * Mathf.Max(
            collLossyScale.x,
            collLossyScale.y,
            collLossyScale.z
        );
    }
    internal void SetShieldSize(Vector3 newSize)
    {
        coll.transform.localScale = newSize;
        CalculateRadius();
    }

    internal Vector3 GetShieldSize() => coll.transform.localScale;
    IEnumerator RunSkill()
    {
        while (true)
        {
            yield return timedEffectRunner.RunEff(DoSkill, SkillEnd, SkillBigin);
            yield return coolDownSystem.RunCoolDown(this);
        }
    }

    void SkillEnd()
    {
        coll.gameObject.SetActive(false);
    }

    void SkillBigin()
    {
        coll.gameObject.SetActive(true);
    }

    void DoSkill()
    {
        var enemies = Physics.OverlapSphere(transform.position, worldRadius, layerMask);
        foreach(var enemy in enemies)
        {
            if(enemy.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(damage, DamageType.Normal);
            }
        }
    }
}
