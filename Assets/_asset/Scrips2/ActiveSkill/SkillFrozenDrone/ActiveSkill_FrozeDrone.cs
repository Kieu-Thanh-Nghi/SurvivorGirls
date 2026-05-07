using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ActiveSkill_FrozeDrone : MonoBehaviour, IHasCoolDown
{
    [SerializeField] AudioSource FrozeDroneSound;
    [SerializeField] Transform frozeDrone;
    [SerializeField] GameObject frozeGas, frozeColl;
    [SerializeField] Vector3 droneScale = Vector3.one;
    [SerializeField] float zoomTime = 0.5f;
    [SerializeField] internal float moveDistance = 5;
    [SerializeField] float rotateTime = 1, moveTime = 3;
    [SerializeField] float baseCoolDown = 8;
    CoolDownSystem coolDownSystem = new();
    float minCoolDown;

    WaitUntil waitUntil;

    private void OnDestroy()
    {
        StopAllCoroutines();
        frozeDrone.DOKill();
        Destroy(frozeDrone.gameObject);
    }
    private void Start()
    {
        minCoolDown = rotateTime * 2 + moveTime;
        StartCoroutine(coolDownSystem.RunEffInCoolDown(DoSkill, this));
        waitUntil = new WaitUntil(() => !DOTween.IsTweening(frozeDrone));
    }

    public float GetCoolDown()
    {
        float realCoolDown = baseCoolDown * PlayerDataManager.Instance._ASCoolDownScale;
        if (realCoolDown <= minCoolDown) realCoolDown = minCoolDown + 1f;
        return 8f;
    }

    [ContextMenu("test")]
    public void DoSkill()
    {
        StopCoroutine(DoSkillCoroutine());
        StartCoroutine(DoSkillCoroutine());
    }
    IEnumerator DoSkillCoroutine()
    {
        Debug.Log("FS: doskill");
        var direct = RandomDirection(frozeDrone);
        frozeDrone.position = transform.position;
        frozeDrone.forward = direct;
        frozeDrone.localScale = Vector3.zero;
        frozeDrone.gameObject.SetActive(true);
        Debug.Log("FS: " + frozeDrone.DOKill());

        ZoomInFrozeDrone();
        yield return waitUntil;
        frozeDrone.SetParent(null);
        RotateDroneAround();
        yield return waitUntil;
        SetActiveFrozenGas(true);
        MoveDrone(direct);
        yield return waitUntil;
        SetActiveFrozenGas(false);
        RotateDroneAround();
        yield return waitUntil;
        frozeDrone.SetParent(transform);
        frozeDrone.gameObject.SetActive(false);
    }
    void SetActiveFrozenGas(bool isActive)
    {
        if (isActive) FrozeDroneSound.Play();
        else FrozeDroneSound.Stop();

        frozeColl.SetActive(isActive);
        frozeGas.SetActive(isActive);
    }
    Tween ZoomInFrozeDrone()
    {
        Debug.Log("FS: zoom in");
        return frozeDrone.DOScale(droneScale, zoomTime);
    }

    Tween RotateDroneAround()
    {
        Debug.Log("FS: rotate");
        return frozeDrone.DORotate(Vector3.up * 360, rotateTime, RotateMode.FastBeyond360).SetRelative(true);
    }

    Tween MoveDrone(Vector3 direct)
    {
        Debug.Log("FS: move");
        return frozeDrone.DOMove(frozeDrone.position + direct * moveDistance, moveTime).SetEase(Ease.Linear);
    }
    Vector3 RandomDirection(Transform target)
    {
        int angle = 90/*Random.Range(0, 360)*/;
        return Quaternion.AngleAxis(angle, target.up) * target.forward;
    }
}
