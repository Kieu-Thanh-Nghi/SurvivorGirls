using System.Collections;
using UnityEngine;

public class PlayerGetDamage : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] Collider playerColl;
    [SerializeField] float hurtImmuteTime = 0.3f;
    WaitForSeconds wait;

    private void Start()
    {
        wait = new WaitForSeconds(hurtImmuteTime);
    }
    private void OnEnable()
    {
        playerColl.enabled = true;
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

    IEnumerator ImmuteMoment()
    {
        health.isImmute = true;
        playerColl.enabled = false;
        yield return wait;
        playerColl.enabled = true;
        health.isImmute = false;
    }
}
