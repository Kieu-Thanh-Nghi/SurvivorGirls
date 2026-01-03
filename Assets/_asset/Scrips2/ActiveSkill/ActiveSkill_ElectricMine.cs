using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using System.Collections;

public class ActiveSkill_ElectricMine : UpdateSkill
{
    [SerializeField] Transform minesContainer;
    [SerializeField] float spawnRadius = 6;
    [SerializeField] int maxMineQuantity = 5;
    [SerializeField] Vector3 mineScale = Vector3.one * 2;
    [SerializeField] Vector3 ShockScale = Vector3.one * 1.5f;
    [SerializeField] float throwHeight = 1.5f;
    [SerializeField] float throwDuration = 1;
    [SerializeField] int currentMineQuantity = 2;
    [SerializeField] float anglePart = 72;
    [SerializeField] int[] posIndexs = { 0, 1, 2, 3, 4 };
    [SerializeField] AEMine minePrafab;
    [SerializeField] List<AEMine> mines;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(StartSkill());
    }
    public override void DoUpdate()
    {
        throw new System.NotImplementedException();
    }
    protected override IEnumerator StartSkill()
    {
        while (true)
        {
            yield return BeginActs();
            yield return waitActiveDuration;
            EndActs();
            yield return waitCountDown;
        }
    }

    IEnumerator BeginActs()
    {
        minesContainer.gameObject.SetActive(true);
        RandomThrowAround(minesContainer, spawnRadius);
        yield return new WaitUntil(() => isActive);
    }

    void EndActs()
    {
        isActive = false;
        minesContainer.gameObject.SetActive(false);
    }
    void RandomThrowAround(Transform target, float radius)
    {
        if(currentMineQuantity < maxMineQuantity)
        {
            RandomSelect(posIndexs, currentMineQuantity, maxMineQuantity);
        }
        for (int i = 0; i < currentMineQuantity; i++)
        {
            float angle = posIndexs[i] * anglePart;
            Vector3 dir = Quaternion.AngleAxis(angle, target.up) * target.forward;
            Transform mineTransform = mines[i].transform;
            mineTransform.localScale = Vector3.zero; 
            Throw(mineTransform, mines[i], Vector3.zero, dir* radius, throwHeight, throwDuration);
            mineTransform.DOScale(mineScale, throwDuration);           
        }
    }

    public void Throw(Transform aMine, AEMine aEMine, Vector3 start, Vector3 end, float height, float duration)
    {
        Vector3 mid = (start + end) * 0.5f + Vector3.up * height;

        Vector3[] path = { start, mid, end };

        aMine.position = start;
        aMine.DOPath(path, duration, PathType.CatmullRom)
            .SetEase(Ease.Linear).OnComplete(() => AciveMine(aEMine));
    }

    void AciveMine(AEMine aEMine)
    {
        aEMine.ActiveShockWave();
        isActive = true;
    }
    [ContextMenu("test")]
    void a()
    {
        RandomThrowAround(minesContainer, spawnRadius);
    }
    public void RandomSelect(int[] list, int n, int m)
    {
        // 2️⃣ Quyết định random cái nào
        bool pickSelected = n <= m / 2;

        if (pickSelected)
        {
            // 🎯 Random n số ĐƯỢC LẤY → đưa lên đầu
            for (int i = 0; i < n; i++)
            {
                int j = Random.Range(i, m);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
        else
        {
            // 🎯 Random (total - n) số KHÔNG LẤY → đưa ra sau

            for (int i = m - 1; i >= n; i--)
            {
                int j = Random.Range(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }

    public void AddAnotherMine()
    {
        var aMine = Instantiate(minePrafab, minesContainer);
        aMine.SetShockWaveScale(ShockScale);
        mines.Add(aMine);
    }

    public void ChangeShockScale(float amount)
    {
        ShockScale *= amount;
        foreach (var mine in mines)
        {
            mine.GetComponent<AEMine>().SetShockWaveScale(ShockScale);
        }
    }
}
