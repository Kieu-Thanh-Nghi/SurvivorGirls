using DG.Tweening;
using UnityEngine;

public class ActiveSkill_FrozeDrone : MonoBehaviour, IHasCoolDown
{
    [SerializeField] Transform frozeDrone;
    [SerializeField] GameObject frozeGas, frozeColl;
    [SerializeField] Vector3 droneScale = Vector3.one;
    [SerializeField] float zoomTime = 0.5f;
    [SerializeField] internal float moveDistance = 5;
    [SerializeField] float rotateTime = 1, moveTime = 3;
    [SerializeField] float baseCoolDown = 8;
    CoolDownSystem coolDownSystem = new();
    float minCoolDown;

    private void OnDestroy()
    {
        StopAllCoroutines();
        DOTween.KillAll();
    }
    private void Start()
    {
        minCoolDown = rotateTime * 2 + moveTime;
        StartCoroutine(coolDownSystem.RunEffInCoolDown(DoSkill, this));   
    }

    public float GetCoolDown()
    {
        float realCoolDown = baseCoolDown * PlayerParaScale.Instance._coolDown;
        if (realCoolDown <= minCoolDown) realCoolDown = minCoolDown + 0.2f;
        return realCoolDown;
    }

    [ContextMenu("test")]
    public void DoSkill()
    {
        var direct = RandomDirection(frozeDrone);
        frozeDrone.position = transform.position;
        frozeDrone.forward = direct;
        frozeDrone.localScale = Vector3.zero;
        frozeDrone.gameObject.SetActive(true);

        DOTween.Sequence()
            .Append(ZoomInFrozeDrone()).OnComplete(() =>
            {
                frozeDrone.SetParent(null);
                DOTween.Sequence()
                    .Append(RotateDroneAround().OnComplete(() => SetActiveFrozenGas(true)))
                    .Append(MoveDrone(direct).OnComplete(() => SetActiveFrozenGas(false)))
                    .Append(RotateDroneAround())
                    .OnComplete(() =>
                    {
                        frozeDrone.gameObject.SetActive(false);
                        frozeDrone.SetParent(transform);
                    });
            });
        //DOTween.Sequence()
        //    .Append(ZoomInFrozeDrone())
        //    .Append(RotateDroneAround().OnComplete(() => SetActiveFrozenGas(true)))
        //    .Append(MoveDrone(direct).OnComplete(() => SetActiveFrozenGas(false)))
        //    .Append(RotateDroneAround())
        //    .OnComplete(() => frozeDrone.gameObject.SetActive(false));
    }

    void SetActiveFrozenGas(bool isActive)
    {
        frozeColl.SetActive(isActive);
        frozeGas.SetActive(isActive);
    }
    Tween ZoomInFrozeDrone()
    {
        return frozeDrone.DOScale(droneScale, zoomTime);
    }

    Tween RotateDroneAround()
    {
        return frozeDrone.DORotate(Vector3.up * 360, rotateTime, RotateMode.FastBeyond360).SetRelative(true);
    }

    Tween MoveDrone(Vector3 direct)
    {
        Debug.Log(frozeDrone.position + direct * moveDistance);
        return frozeDrone.DOMove(frozeDrone.position + direct * moveDistance, moveTime).SetEase(Ease.Linear);
    }
    Vector3 RandomDirection(Transform target)
    {
        int angle = 90/*Random.Range(0, 360)*/;
        return Quaternion.AngleAxis(angle, target.up) * target.forward;
    }
}
