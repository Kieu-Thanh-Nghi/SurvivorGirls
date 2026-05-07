using Lean.Pool;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class LvlPoint : MonoBehaviour, IExp
{
    [SerializeField] int type;
    [SerializeField] Collider expColl;
    [SerializeField] int expPoint;
    bool isPicked;
    //WaitUntil waitUntil;

    //private void Start()
    //{
    //    waitUntil = new WaitUntil(() => Going());
    //}

    public Transform PickThisExp(LevelManager whoPicked)
    {
        if (isPicked) return null;
        isPicked = true;
        expColl.enabled = false;
        transform.SetParent(whoPicked.transform, true);
        AttractToTarget(whoPicked);
        return transform;
    }

    //IEnumerator AttractToTarget(LevelManager whoPicked)
    //{
    //    yield return waitUntil;
    //    AddExperience(whoPicked);
    //}

    //bool Going()
    //{
    //    float step = 4 * Time.deltaTime;
    //    transform.position = Vector3.MoveTowards(transform.position, transform.parent.position, step);
    //    if (transform.localPosition == Vector3.zero)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    void AttractToTarget(LevelManager whoPicked)
    {
        transform.DOLocalMove(Vector3.zero, 0.75f).SetEase(Ease.InBack).OnComplete(() => AddExperience(whoPicked));
    }

    void AddExperience(LevelManager whoPicked)
    {
        whoPicked.expInOneFrame += Mathf.CeilToInt(expPoint * PlayerDataManager.Instance._gotExpScale);
        gameObject.SetActive(false);
        LeanPool.Despawn(gameObject);
    }

    public new int GetType()
    {
        return type;
    }

    private void OnDisable()
    {
        isPicked = false;
        expColl.enabled = true;
    }
}
