using UnityEngine;
using UnityEngine.UI;

public class WeaponFrameColorChanger : MonoBehaviour
{
    [SerializeField] Image weaponFrame;
    [SerializeField] Image weaponBG;

    public void changeFrameAndBGByRank(int rankIndex)
    {
        if (rankIndex >= Database.instance.ItemRankArr.Length || rankIndex < 0) return;
        var uiDatas = UIDatas.Instance;
        var wFrame = uiDatas.rankFrame[rankIndex];
        var wBG = uiDatas.rankWeaponBGs[rankIndex];

        weaponFrame.sprite = wFrame;
        weaponBG.sprite = wBG;
    }
}