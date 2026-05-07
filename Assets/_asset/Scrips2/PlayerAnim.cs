using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnEnable()
    {
        animator = PlayerSetup.instance.playerSkin.GetComponent<Animator>();
    }

    public void DoMoveAnim(IMoveAnim moveAnim, Vector3 moveDirect, float moveSpeed, AnimID animID)
    {
        moveAnim.DoAnim(animator, animID, moveSpeed, moveDirect);
    }
}
