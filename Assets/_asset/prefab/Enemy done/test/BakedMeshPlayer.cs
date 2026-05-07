using UnityEngine;

public class BakedMeshPlayer : MonoBehaviour
{
    public Mesh[] frames;

    [Header("Playback")]
    public float fps = 30f;
    public float speed = 1f; // 👈 chỉnh tốc độ ở đây
    public bool loop = true;

    private MeshFilter meshFilter;
    private float currentTime; // dùng time thay vì frame
    private int frameCount;

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        frameCount = frames != null ? frames.Length : 0;
    }

    void Update()
    {
        if (frameCount == 0) return;

        // 👇 cộng thời gian có nhân speed
        currentTime += Time.deltaTime * speed;

        float totalDuration = frameCount / fps;

        if (loop)
        {
            currentTime %= totalDuration;
        }
        else
        {
            currentTime = Mathf.Min(currentTime, totalDuration);
        }

        // 👇 tính frame từ time
        float frameFloat = currentTime * fps;
        int frameIndex = Mathf.FloorToInt(frameFloat);

        frameIndex = Mathf.Clamp(frameIndex, 0, frameCount - 1);

        meshFilter.mesh = frames[frameIndex];
    }

    // 🎮 API tiện dùng
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void Play()
    {
        enabled = true;
    }

    public void Pause()
    {
        enabled = false;
    }

    public void Stop()
    {
        currentTime = 0f;
        if (frameCount > 0)
            meshFilter.mesh = frames[0];
    }
}