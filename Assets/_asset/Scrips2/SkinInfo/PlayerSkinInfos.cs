using UnityEngine;

public class PlayerSkinInfos : MonoBehaviour
{
    [SerializeField] internal ParticleSystem 
        playerHit,
        bigHeal,
        smallHeal;

    [SerializeField] bool isValidate;
    private void OnValidate()
    {
        if (!isValidate) return;
        playerHit = FindByName("Player_Hit01")?.GetComponentInChildren<ParticleSystem>();
        bigHeal = FindByName("Hearth_End_Player")?.GetComponentInChildren<ParticleSystem>();
        smallHeal = FindByName("PassiveHeal")?.GetComponentInChildren<ParticleSystem>();
    }

    Transform FindByName(string name)
    {
        var additionals = transform.Find("Additionals");
        return additionals.Find(name);
    }
}
