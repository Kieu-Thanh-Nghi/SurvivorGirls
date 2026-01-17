using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RushSkill : BaseRushSkill
{
    protected void OnEnable()
    {
        coll.enabled = true;
    }

    protected override void AfterSkill(Sequence doingSkill)
    {
        doingSkill.AppendInterval(coolDown).OnComplete(() => EndSkill());
    }
}