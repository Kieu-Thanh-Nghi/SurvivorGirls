using System.Collections;
using TigerForge;
using UnityEngine;
using UnityEngine.Audio;

public class Setting : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    private void OnEnable()
    {
        var GPCtrler = GamePlayCtrler.Instance;
        if (GPCtrler != null) GPCtrler.IsPause = true;
    }
    private void OnDisable()
    {
        var GPCtrler = GamePlayCtrler.Instance;
        if (GPCtrler != null) GPCtrler.IsPause = false;
    }
    public void OnOffMusic(bool isOn)
    {
        Debug.Log("Setting: " + isOn);
        if(isOn) audioMixer.SetFloat("music", 0);
        else audioMixer.SetFloat("music", -80);
    }
    public void OnOffSfx(bool isOn)
    {
        Debug.Log("Setting: " + isOn);
        if (isOn) audioMixer.SetFloat("sfx", 0);
        else audioMixer.SetFloat("sfx", -80);
    }

    public void BackToMenu()
    {
        EventManager.EmitEvent(GameEvents.EndGameImmediate.ToString());
    }
}

public enum SettingEnum
{
    MusicVolumSetting,
    SfxVolumSetting
}