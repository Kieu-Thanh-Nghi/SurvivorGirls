using System.Collections.Generic;
using UnityEngine;

public class GameBoostUp : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    [ContextMenu("ss")]
    void ToMenuScene()
    {
        SceneCtrler.instance.ChangeToMenuScene();
    }

    private void Update()
    {
        ToMenuScene();
        enabled = false;
    }
}
