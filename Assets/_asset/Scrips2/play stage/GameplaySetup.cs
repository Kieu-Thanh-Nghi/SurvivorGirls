using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySetup : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject SkillChoiceCanvas;
    [SerializeField] Image lvlProgressBar;
    [SerializeField] TMP_Text currentLvlText;
    
    public void SetupPlayer()
    {
        var lvlManager = PlayerSetup.instance.levelManager;
        lvlManager.SkillChoiceCanvas = SkillChoiceCanvas;
        lvlManager.lvlProgressBar = lvlProgressBar;
        lvlManager.currentLvlText = currentLvlText;
        SkillChoiceCanvas.SetActive(false);
        lvlProgressBar.fillAmount = 0;
        currentLvlText.text = "1";

        PlayerSetup.instance.PlayerHPBarCanvas.worldCamera = mainCam;

        var player = PlayerSetup.instance.player;
        player.position = Vector3.zero;
        player.gameObject.SetActive(true);
    }
}
