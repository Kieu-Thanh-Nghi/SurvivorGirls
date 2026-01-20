using Lean.Pool;
using UnityEngine;

public class ActiveSkill_ThunderBolts : MonoBehaviour, IHasCoolDown
{
    ObjectsSphereRandomDetecter detecter = new();
    CoolDownSystem coolDownSystem = new();
    [SerializeField] LeanGameObjectPool thunderBoltsPool;
    [SerializeField] ThunderBoltsElectricEff electricEff;
    [SerializeField] float baseCoolDown = 4;
    [SerializeField] internal int neededEnemies = 1;
    [SerializeField] float detectRadius = 8;
    [SerializeField] LayerMask layer;
    Transform[] enemies = new Transform[10];
    internal float EShockTime 
    { 
        set => electricEff.SetElecEffTime(value);
        get => electricEff.GetElecEffTime();
    }

    public float GetCoolDown() => baseCoolDown * PlayerDataManager.Instance._ASCoolDownScale;

    private void Start()
    {
        StartCoroutine(coolDownSystem.RunEffInCoolDown(DoSkill, this));
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    [ContextMenu("testLightning")]
    public void DoSkill()
    {
        int n = detecter.DetectEnemiesNonAlloc(transform.position, detectRadius, neededEnemies, layer, enemies);
        for(int i = 0; i < n; i++)
        {
            Strike(enemies[i].position);
        }
    }

    void Strike(Vector3 position)
    {
        thunderBoltsPool.Spawn(position);
    }
}
