using DG.Tweening;
using UnityEngine;

public class ActiveSkill_FrozeDrone : MonoBehaviour
{
    [SerializeField] Transform frozeDrone;
    [SerializeField] GameObject frozeGas;
    [SerializeField] Vector3 droneScale = Vector3.one;
    [SerializeField] float zoomTime = 0.5f;
    [SerializeField] float moveDistance = 5;
    [SerializeField] float rotateTime = 1, moveTime = 3;

    private void Start()
    {
        frozeDrone.SetParent(null);
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
            .Append(ZoomInFrozeDrone())
            .Append(RotateDroneAround().OnComplete(() => SetActiveFrozenGas(true)))
            .Append(MoveDrone(direct).OnComplete(() => SetActiveFrozenGas(false)))
            .Append(RotateDroneAround())
            .OnComplete(() => frozeDrone.gameObject.SetActive(false));
    }

    void SetActiveFrozenGas(bool isActive)
    {
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
        return frozeDrone.DOMove(frozeDrone.position + direct * moveDistance, moveTime);
    }
    Vector3 RandomDirection(Transform target)
    {
        int angle = Random.Range(0, 360);
        return Quaternion.AngleAxis(angle, target.up) * target.forward;
    }
}
