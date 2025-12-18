using UnityEngine;
using Lean.Pool;

public class EnemyHurt : MonoBehaviour
{
    [SerializeField] ParticleSystem HurtEff;
    [SerializeField] Health health;
    internal DameText dameText;

    private void Start()
    {
        var pool = GamePlayCtrler.Instance.dameTextPool;
        var damageText = pool.Spawn(pool.transform);
        damageText.SetActive(false);
        if (damageText.TryGetComponent<DameText>(out var theText)) dameText = theText;
        health.OnTakeDamage += DameTextAppear;
    }
    public void EnemyBleed()
    {
        HurtEff.Play();
    }

    public void DameTextAppear(int theDamage)
    {
        dameText.SetPosition(transform.position);
        dameText.SetText(theDamage.ToString());
        dameText.gameObject.SetActive(true);
    }
}
