using DG.Tweening;
using UnityEngine;
using Lean.Pool;
using UnityEngine.Events;

public class ActiveSkill_FireWorks : MonoBehaviour, IHasDamage, IHasCoolDown
{
    [SerializeField] float baseCooldown;
    [SerializeField] Transform user;
    [SerializeField] int burnDamage;
    [SerializeField] internal Vector3 FireCrackerScale = Vector3.one * 0.4f;
    [SerializeField] LeanGameObjectPool FireWorksPool;
    [SerializeField] LeanGameObjectPool FireCrackerPool;
    [SerializeField] float FWRadius, FCRadius, DetectRadius, AlternativeRadius;
    [SerializeField] float throwHeight = 1.5f;
    [SerializeField] float throwDuration = 1;
    [SerializeField] LayerMask layerMask;
    Collider[] detectedEnemy = new Collider[1];
    CoolDownSystem coolDownSystem = new();
    private void Start()
    {
        StartCoroutine(coolDownSystem.RunEffInCoolDown(DoSkill, this));
    }
    public float GetCoolDown() => baseCooldown * PlayerDataManager.Instance._ASCoolDownScale;
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
    [ContextMenu("test")]
    public void DoSkill()
    {
        var Dir = RandomDirection(user);
        Transform FWorksTransform = FireWorksPool.Spawn(null).transform;
        RandomThrowFWorks(user.position, user.position + Dir * FWRadius, FWorksTransform, 
            () => 
            {
                Vector3 enemyPos = CircleEnemyDetect(Dir, DetectRadius);
                var FCrackerTransform = FireCrackerPool.Spawn(null).transform;
                FCrackerTransform.localScale = Vector3.zero;
                ThrowFCracker(FWorksTransform.position, enemyPos, FCrackerTransform);
                FireWorksPool.Despawn(FWorksTransform.gameObject);
            });
    }

    void RandomThrowFWorks(Vector3 fromPos, Vector3 toPos, Transform projectileTransform, UnityAction DoWhenDone = null)
    {
        Throw(projectileTransform, fromPos, toPos, throwHeight, throwDuration, DoWhenDone);
    }
    Vector3 CircleEnemyDetect(Vector3 direct, float radius)
    {
        Vector3 detectPos = user.position + direct * FCRadius;
        int n = Physics.OverlapSphereNonAlloc(detectPos, radius, detectedEnemy, layerMask);
        if(n > 0)
        {
            return detectedEnemy[0].transform.position;
        }
        else
        {
            return user.position + direct * AlternativeRadius;
        }
    }
    Vector3 RandomDirection(Transform from)
    {
        int angle = Random.Range(0, 360);
        return Quaternion.AngleAxis(angle, from.up) * from.forward;
    }
    void ThrowFCracker(Vector3 fromPos, Vector3 toPos, Transform projectileTransform)
    {
        projectileTransform.DOScale(FireCrackerScale, throwDuration);
        Throw(projectileTransform, fromPos, toPos, throwHeight, throwDuration, () => FireCrackerPool.Despawn(projectileTransform.gameObject));
    }

    public void Throw(Transform aMine, Vector3 start, Vector3 end, float height, float duration, UnityAction DoWhenDone = null)
    {
        Vector3 mid = (start + end) * 0.5f + Vector3.up * height;

        Vector3[] path = { start, mid, end };

        aMine.position = start;
        aMine.DOPath(path, duration, PathType.CatmullRom)
            .SetEase(Ease.Linear).OnComplete(() => DoWhenDone?.Invoke());
    }

    public int GetDamage() => burnDamage;

}
