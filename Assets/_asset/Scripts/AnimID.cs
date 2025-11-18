using UnityEngine;

public class AnimID : MonoBehaviour
{
    [SerializeField] internal int movingPara;

    private void OnValidate()
    {
        movingPara = Animator.StringToHash("movingSpeed");
    }
}
