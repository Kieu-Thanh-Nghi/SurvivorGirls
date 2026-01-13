using System.Collections;
using UnityEngine;

public class PlayerGetDamage : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] float hurtImmuteTime = 0.3f;
    WaitForSeconds wait;

    private void Start()
    {
        wait = new WaitForSeconds(hurtImmuteTime);
    }
    public void PlayerHurt()
    {
        StopAllCoroutines();
        StartCoroutine(ImmuteMoment());
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent<IHasHurtDamage>(out var hasHurtDamage))
        {
            health.TakeDamage(hasHurtDamage.GetHurtDamage(), DamageType.Normal);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IHasHurtDamage>(out var hasHurtDamage))
        {
            health.TakeDamage(hasHurtDamage.GetHurtDamage(), DamageType.Normal);
        }
    }

    IEnumerator ImmuteMoment()
    {
        health.isImmute = true;
        yield return wait;
        health.isImmute = false;
    }
}
