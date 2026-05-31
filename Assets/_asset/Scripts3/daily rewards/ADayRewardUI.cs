using UnityEngine;
using UnityEngine.UI;

public class ADayRewardUI : MonoBehaviour
{
    [SerializeField] Image glowOutline;
    [SerializeField] GameObject CheckMark;
    public void SetUIStatus(int status)
    {
        bool isAvalable = false;
        bool hasAchived = false;
        switch (status)
        {
            case 1: 
                isAvalable = true;
                break;
            case 2:
                hasAchived = true;
                break;
        }
        glowOutline.enabled = isAvalable;
        CheckMark.SetActive(hasAchived);
    }
}
