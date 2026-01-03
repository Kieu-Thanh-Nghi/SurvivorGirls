using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ActiveSkill_BladeDrone : UpdateSkill
{
    [SerializeField] internal List<Transform> BladeDrones = new List<Transform>(5);
    [SerializeField] internal Transform BladesContainer;
    [SerializeField] internal Vector3 bladeScale;
    [SerializeField] Transform BladeDronePrefab;
    [SerializeField] float rotateSpeed;
    [SerializeField] float radius;
    float realRotateSpeed => rotateSpeed * PlayerParaScale.Instance._objectProjectileSpeed;
    float realRadius => radius * PlayerParaScale.Instance._areaRadius;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(StartSkill());
    }
    public override void DoUpdate()
    {
        if (isActive)
        {
            RotateBlades();
        }
    }
    protected override void BeforeActiveSkill()
    {
        RevealBlades();
        base.BeforeActiveSkill();
    }
    protected override void AfterActiveSkill()
    {
        base.AfterActiveSkill();
        RetriveBlades();
    }
    void RotateBlades()
    {
        BladesContainer.Rotate(0, realRotateSpeed * Time.deltaTime, 0);
    }

    void RevealBlades()
    {
        BladesContainer.gameObject.SetActive(true);
        foreach(var blade in BladeDrones)
        {
            blade.DOLocalMove(blade.forward * realRadius, 0.4f);
            blade.DOScale(bladeScale, 0.4f);
        }
    }
    void RetriveBlades()
    {
        var seq = DOTween.Sequence();
        foreach (var blade in BladeDrones)
        {
            seq.Join(blade.DOLocalMove(Vector3.zero, 0.4f));
            seq.Join(blade.DOScale(Vector3.zero, 0.4f));
        }
        seq.OnComplete(() => BladesContainer.gameObject.SetActive(false));
    }
    internal void SummonAnotherBlade()
    {
        var bladeDrone = Instantiate(BladeDronePrefab, BladesContainer);
        BladeDrones.Add(bladeDrone);
        int n = BladeDrones.Count;
        float angle = (float)360 / n;
        for(int i = 0; i < n; i++)
        {
            Vector3 Direct = Quaternion.Euler(0, angle * i, 0) * Vector3.forward;
            BladeDrones[i].forward = Direct;
        }
        if (n >= 1) bladeDrone.localScale = Vector3.zero;
    }
}
