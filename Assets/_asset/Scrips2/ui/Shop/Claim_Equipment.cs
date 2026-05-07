using UnityEngine;
using UnityEngine.UI;
public class Claim_Equipment : Claim_Reward<Equipment>
{
    [SerializeField] Image rankIconImage, EquipmtIconImage, rankFrameImage;
    public override void ShowRewardQuantity(Equipment equipment)
    {
        var theRank = equipment.rank;
        var theType = equipment.equipType;
        var theMat = equipment.equipMat;

        var equiIcon = UIDatas.Instance.equipIconsList[(int)theType].icons[(int)theMat];
        var rankIcon = UIDatas.Instance.rankIcon[(int)theRank];
        var rankFrame = UIDatas.Instance.rankBg[(int)theRank];

        rankIconImage.sprite = rankIcon;
        EquipmtIconImage.sprite = equiIcon;
        rankFrameImage.sprite = rankFrame;
    }
}