using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    [SerializeField] ParticleSystem HurtEff;
    public void EnemyBleed()
    {
        HurtEff.Play();
    }
}