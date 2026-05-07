using UnityEngine;
using System.Collections;

public class ActiveSkill_TentaclesRobot : UpdateSkill, IHasDamage
{
    [SerializeField] AudioSource StartSelfDestructSound, SelfExploSound;
    [SerializeField] internal Transform user;
    [SerializeField] float spawnRadius = 6;
    [SerializeField] ParticleSystem seftDistruct;
    [SerializeField] TentacBotAttractEnemies tentacBotAttract;
    [SerializeField] GameObject RobotAllBody;
    [SerializeField] GameObject VisualBody;
    [SerializeField] Transform effCollider;
    [SerializeField] int exploDamage;

    internal int realExploDamge => exploDamage;
    public void SetIsActive(bool _isActive) => isActive = _isActive;

    protected override void Start()
    {
        tentacBotAttract.hasDamage = this;
        RobotAllBody.transform.SetParent(null);
        base.Start();
        StartCoroutine(StartSkill());
    }
    public void OnDestroy()
    {
        Destroy(RobotAllBody);
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
        int angle = Random.Range(0, 360);
        Vector3 dir = Quaternion.AngleAxis(angle, target.up) * target.forward;
        return target.position + dir * radius;
    }

    IEnumerator BeginActs()
    {
        tentacBotAttract.isSeftDistruct = false;
        RobotAllBody.transform.position = RandomAround(user, spawnRadius);
        VisualBody.SetActive(true);
        yield return new WaitUntil(() => isActive);
        tentacBotAttract.transform.localPosition = Vector3.zero;
    }
    IEnumerator EndActs()
    {
        ActiveExplotion();
        yield return new WaitForSeconds(2f);
        SelfExploSound.Play();
        StartSelfDestructSound.Stop();
        tentacBotAttract.isSeftDistruct = true;
        tentacBotAttract.transform.localPosition = Vector3.down * 10;
        VisualBody.SetActive(false);
        isActive = false;
    }

    void ActiveExplotion()
    {
        StartSelfDestructSound.Play();
        seftDistruct.Play();
    }

    public int GetDamage() => exploDamage;

    public DamageType GetDamageType()
    {
        return DamageType.Normal;
    }
}
