using UnityEngine;

public class RewardScreenOpener : MonoBehaviour
{
    [SerializeField] Sprite icon;

    public void SetRewardScreen(int number)
    {
        UIManager.instance.menuShop.rewardUI.OpenUI(icon, number);
    }
}