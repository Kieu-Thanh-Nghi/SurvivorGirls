using UnityEngine;

public class ScifiDroneWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] internal ProjectileEmiter emiter;
    [SerializeField] Transform[] gunPos;
    int currentGunIndex = 0;

    private void Start()
    {
        emiter.SetHasDamageData(GetComponent<IHasDamage>());
    }
    public void DoOneAttack(Vector3 targetPos)
    {
        currentGunIndex -= 1;
        currentGunIndex = Mathf.Abs(currentGunIndex);
        Vector3 shotPos = gunPos[currentGunIndex].position;
        emiter.transform.position = shotPos;
        emiter.transform.forward = (targetPos - shotPos).normalized;
        emiter.Emit();
    }
}
