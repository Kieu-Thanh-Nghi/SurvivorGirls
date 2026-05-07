using TMPro;
using UnityEngine;

public class WeaponRankupConfirm : MonoBehaviour
{
    [SerializeField] TMP_Text confirm;
    public void OpenConfirmUI(int chipQuantity)
    {
        confirm.text = "Would you like to upgrade by using " + chipQuantity.ToString() + " weapon chips?";
        gameObject.SetActive(true);
    }
}
