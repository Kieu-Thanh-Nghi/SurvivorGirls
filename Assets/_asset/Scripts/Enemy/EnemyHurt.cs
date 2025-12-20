using UnityEngine;
using Lean.Pool;

public class EnemyHurt : MonoBehaviour
{
    [SerializeField] ParticleSystem HurtEff;
    [SerializeField] Health health;
    [SerializeField] Transform Head;
    internal DameText dameText;

    private void Start()
    {
        //var pool = GamePlayCtrler.Instance.dameTextPool;
        //var damageText = pool.Spawn(transform.position, pool.transform.rotation, pool.transform);
        //damageText.SetActive(false);
        //if (damageText.TryGetComponent<DameText>(out var theText)) dameText = theText;
        health.OnTakeDamage += DameTextAppear;
    }
    public void EnemyBleed()
    {
        HurtEff.Play();
    }

    public void DameTextAppear(int theDamage)
    {
        var pool = GamePlayCtrler.Instance.dameTextPool;
        var damageText = pool.Spawn(transform.position, pool.transform.rotation, pool.transform);
        if (damageText.TryGetComponent<DameText>(out var theText))
        {
            theText.SetText(theDamage.ToString());
            theText.SetPosition(Head.position);
        }

        //dameText.SetText(theDamage.ToString());
        //dameText.SetPosition(Head.position);
        //dameText.gameObject.SetActive(true);
        //dameText.ActiveEff();
    }
}
