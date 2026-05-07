using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Slider progressBar;
    [SerializeField] private TMP_Text progressText;

    [Header("Config")]
    [SerializeField] private float minLoadingTime = 2f; // thời gian tối thiểu

    private float currentProgress = 0f;

    public void LoadScene(string sceneName)
    {
        gameObject.SetActive(true);
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        float timer = 0f;

        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            timer += Time.unscaledDeltaTime;

            // progress thực tế (0 → 0.9)
            float realProgress = Mathf.Clamp01(op.progress / 0.9f);

            // fake progress để đảm bảo minLoadingTime
            float timeProgress = Mathf.Clamp01(timer / minLoadingTime);

            // lấy cái thấp hơn để tránh vượt quá
            currentProgress = Mathf.Min(realProgress, timeProgress);

            UpdateUI(currentProgress);

            // Khi đã load xong và đủ thời gian → cho vào scene
            if (realProgress >= 1f && timer >= minLoadingTime)
            {
                UpdateUI(1f);
                op.allowSceneActivation = true;
            }

            yield return null;
        }
        gameObject.SetActive(false);
    }

    private void UpdateUI(float value)
    {
        if (progressBar != null)
            progressBar.value = value;

        if (progressText != null)
            progressText.text = Mathf.RoundToInt(value * 100f) + "%";
    }
}
