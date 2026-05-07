using TigerForge;
using UnityEngine;

public class GameEventCatcher : MonoBehaviour
{
    [SerializeField] internal string PrefsSaveKey;
    [SerializeField] GameEvents gameEvents;

    private void Start()
    {
        EventManager.StartListening(gameEvents.ToString(), EventCallBack);
    }

    void EventCallBack()
    {
        if (PlayerPrefs.HasKey(PrefsSaveKey))
        {
            var current = PlayerPrefs.GetInt(PrefsSaveKey);
            if (current < 0) return;
            PlayerPrefs.SetInt(PrefsSaveKey, current + 1);
        }
        else
        {
            PlayerPrefs.SetInt(PrefsSaveKey, 1);
        }
        PlayerPrefs.Save();
    }
}
