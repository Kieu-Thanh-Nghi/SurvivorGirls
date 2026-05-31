using System.Collections;
using System.Collections.Generic;
using TigerForge;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class Setting : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    public static Setting Instance;
    public List<UnityAction<bool>> OnOffASetting = new();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey(SettingEnum.MusicVolumSetting.ToString()))
        {
            PlayerPrefs.SetInt(SettingEnum.MusicVolumSetting.ToString(), 1);
            OnOffMusic(true);
        }
        if (!PlayerPrefs.HasKey(SettingEnum.SfxVolumSetting.ToString()))
        {
            PlayerPrefs.SetInt(SettingEnum.SfxVolumSetting.ToString(), 1);
            OnOffSfx(true);
        }
        OnOffASetting.Clear();
        OnOffASetting.Add(OnOffMusic);
        OnOffASetting.Add(OnOffSfx);
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
}

public enum SettingEnum
{
    MusicVolumSetting = 0,
    SfxVolumSetting = 1
}