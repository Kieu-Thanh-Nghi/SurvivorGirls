using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public TMP_Text fpsText;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5f)
        {
            float fps = 1f / Time.deltaTime;
            fpsText.text = "FPS: " + Mathf.RoundToInt(fps);
            timer = 0f;
        }
    }
}
