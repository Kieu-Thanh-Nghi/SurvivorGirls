using UnityEngine;

public class AnimatorPlayer : CharAnimManagement
{
    [SerializeField] Animator animator;

    public override float Speed
    {
        get => animator.speed;
        set
        {
            if (value > 1.5f)
            {
                animator.speed = 1.5f;
            }
            else
            {
                animator.speed = value;
            }
        }
    }

    public override void SetStopCurrentAnim(bool isStop)
    {
        if (isStop)
        {
            animator.speed = 0;
        }
        else
        {
            animator.speed = 1;
        }
    }

    public override void UpdateAnimFrame() { }
}