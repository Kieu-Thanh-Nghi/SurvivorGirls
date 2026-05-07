using UnityEngine;

//public class VATPlayer : MonoBehaviour
//{
//    [SerializeField] string frameName = "_Frame";
//    [SerializeField] string startFrameName = "_startFrame";
//    [SerializeField] string frameCountName = "_frameCount";
//    [SerializeField] string totalFrameName = "_TotalFrames";
//    public float fps = 30f;
//    public float speed = 1f;

//    public VATAnimData data;

//    Renderer rend;
//    MaterialPropertyBlock mpb;

//    float time;

//    int startFrame;
//    int frameCount;
//    int totalFrames;

//    void Awake()
//    {
//        rend = GetComponent<Renderer>();
//        mpb = new MaterialPropertyBlock();
//    }

//    private void Start()
//    {
//        PlayByIndex(0);
//    }

//    public void PlayByName(string animName)
//    {
//        if (data.TryGetAnim(animName, out int start, out int count))
//        {
//            Play(start, count, data.totalFrames);
//        }
//    }
//    public void PlayByIndex(int index)
//    {
//        if (data.TryGetAnim(index, out int start, out int count))
//        {
//            Play(start, count, data.totalFrames);
//        }
//    }
//    public void Play(int newStart, int newCount, int total)
//    {
//        startFrame = newStart;
//        frameCount = newCount;
//        totalFrames = total;

//        time = 0f;
//    }
//    public void UpdateAnimFrame()
//    {
//        time += Time.deltaTime * speed;

//        float frame = time * fps;
//        frame %= frameCount;

//        rend.GetPropertyBlock(mpb);

//        mpb.SetFloat(frameName, frame);
//        mpb.SetFloat(startFrameName, startFrame);
//        mpb.SetFloat(frameCountName, frameCount);
//        mpb.SetFloat(totalFrameName, totalFrames);

//        rend.SetPropertyBlock(mpb);
//    }
//    //void Update()
//    //{
//    //    time += Time.deltaTime * speed;

//    //    float frame = time * fps;
//    //    frame %= frameCount;

//    //    rend.GetPropertyBlock(mpb);

//    //    mpb.SetFloat(totalFrameName, totalFrames);
//    //    mpb.SetFloat(startFrameName, startFrame);
//    //    mpb.SetFloat(frameCountName, frameCount);
//    //    mpb.SetFloat(frameName, frame);

//    //    rend.SetPropertyBlock(mpb);
//    //}
//}
public class VATPlayer : CharAnimManagement
{
    [SerializeField] string frameName = "_Frame";
    [SerializeField] string totalFrameName = "_TotalFrames";
    [SerializeField] Renderer rend;
    [SerializeField] float fps = 30f;
    [SerializeField] public int totalFrames = 30;
    [SerializeField] float speed = 1f;
    [SerializeField] float speedOffset = 0.4f;
    float speedFinal => speed * speedOffset;

    bool isStop = false;
    float time;
    MaterialPropertyBlock mpb;

    public override float Speed { 
        get => speed;
        set
        {
            if (value > 1.5f)
            {
                speed = 1.5f;
            }
            else
            {
                speed = value;
            }     
        }
    }

    private void OnValidate()
    {
        rend = GetComponent<Renderer>();
    }

    void Awake()
    {
        mpb = new MaterialPropertyBlock();
    }

    public override void UpdateAnimFrame()
    {
        if (isStop) return;
        if(mpb == null)
        {
            mpb = new MaterialPropertyBlock();
        }
        time += Time.deltaTime * speedFinal;

        float frame = (time * fps) % totalFrames;

        rend.GetPropertyBlock(mpb);
        mpb.SetFloat(frameName, frame);
        mpb.SetFloat(totalFrameName, totalFrames);
        rend.SetPropertyBlock(mpb);
    }

    public override void SetStopCurrentAnim(bool isStop)
    {
        this.isStop = isStop;
    }

    //void Update()
    //{
    //    time += Time.deltaTime * speed;

    //    float frame = (time * fps) % totalFrames;

    //    rend.GetPropertyBlock(mpb);
    //    mpb.SetFloat(frameName, frame);
    //    mpb.SetFloat(totalFrameName, totalFrames);
    //    rend.SetPropertyBlock(mpb);
    //}
}

public abstract class CharAnimManagement : MonoBehaviour
{
    public abstract float Speed
    {
        get;
        set;
    }
    public abstract void UpdateAnimFrame();

    public abstract void SetStopCurrentAnim(bool isStop);
}
