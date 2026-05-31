using UnityEngine;
using Lean.Pool;

public class KatanaSlash : MonoBehaviour
{
    [SerializeField] string theTag = "projectile";
    [SerializeField] KatanaSlash rootSlash;
    [SerializeField] LeanGameObjectPool parasitePool;
    internal bool IsBulletCut;
    internal bool IsDeflect;
    internal int DeflectTimes;
    internal float SizeBuff = 1;
    int DeflectCount;
    private void OnTriggerEnter(Collider other)
    {
        if (!IsBulletCut) return;
        if (other.CompareTag(theTag))
        {
            if(IsDeflect && DeflectCount < DeflectTimes)
            {
                var p = parasitePool.Spawn(other.transform);
                p.GetComponent<ProjectileParasite>().SetupThis(other, gameObject.layer, SizeBuff);
                other.transform.forward = -other.transform.forward;
                if(other.TryGetComponent(out IProjectile projectile))
                {
                    projectile.DoFly();
                }
                DeflectCount++;
            }
            else
            {
                LeanPool.Despawn(other.gameObject);
            }
        }
    }
    public void ConfigSlash()
    {
        IsBulletCut = rootSlash.IsBulletCut;
        IsDeflect = rootSlash.IsDeflect;
        DeflectTimes = rootSlash.DeflectTimes;
        SizeBuff = rootSlash.SizeBuff;
    }
    private void OnEnable()
    {
        DeflectCount = 0;
        ConfigSlash();
        Debug.Log("KatanaSlash " + IsBulletCut);
    }
}
