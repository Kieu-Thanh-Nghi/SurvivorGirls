using UnityEngine;
using System.Collections;

public class ActiveSkill_TentaclesRobot : UpdateSkill
{
    [SerializeField] internal Transform user;
    [SerializeField] float spawnRadius = 6;
    [SerializeField] ParticleSystem seftDistruct;
    [SerializeField] TentacBotAttractEnemies tentacBotAttract;
    [SerializeField] GameObject RobotAllBody;
    [SerializeField] Collider effCollider;
    [SerializeField] int exploDamage;

    internal int realExploDamge => exploDamage;
    public void SetIsActive(bool _isActive) => isActive = _isActive;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(StartSkill());
    }
    public override void DoUpdate()
    {
    }
    protected override IEnumerator StartSkill()
    {
        while (true)
        {
            yield return BeginActs();
            yield return waitActiveDuration;
            yield return EndActs();
            yield return waitCountDown;
        }
    }

    Vector3 RandomAround(Transform target, float radius)
    {
        float angle = Random.Range(0f, 360f);
        Vector3 dir = Quaternion.AngleAxis(angle, target.up) * target.forward;
        return target.position + dir * radius;
    }

    IEnumerator BeginActs()
    {
        transform.position = RandomAround(user, spawnRadius);
        RobotAllBody.SetActive(true);
        yield return new WaitUntil(() => isActive);
        effCollider.enabled = true;
    }
    IEnumerator EndActs()
    {
        ActiveExplotion();
        yield return new WaitForSeconds(2f);
        tentacBotAttract.DamageEnemies(realExploDamge);
        yield return new WaitUntil(() => !isActive);
        effCollider.enabled = false;
        RobotAllBody.SetActive(false);
    }

    void ActiveExplotion()
    {
        seftDistruct.Play();
    }
}
