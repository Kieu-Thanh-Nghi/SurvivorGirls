using UnityEngine;

public class AtkSystem : MonoBehaviour
{
    [SerializeField] internal float AttackCountdown;
    [SerializeField] internal BasicWeapon weapon;
    [SerializeField] Transform targetPos;
    [SerializeField] float t;
    internal Animator animator;
    float startTime;

    private void Start()
    {
        startTime = Time.time - AttackCountdown;
    }
    private void Update()
    {
        t = Time.time - startTime;
        if (Time.time - startTime >= AttackCountdown)
        {
            animator?.SetTrigger("MeleAttack");
            startTime = Time.time;
            t = Time.time;
        }
    }

    public void DoAttack()
    {
        weapon.DoOneAttack(targetPos.position);
    }
}