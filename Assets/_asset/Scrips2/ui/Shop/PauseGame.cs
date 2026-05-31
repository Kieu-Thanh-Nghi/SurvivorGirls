using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private void OnEnable()
    {
        GamePlayCtrler.Instance.IsPause = true;
    }

    private void OnDisable()
    {
        GamePlayCtrler.Instance.IsPause = false;
    }
}