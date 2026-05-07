using UnityEngine;

public class AnimThrowingAdapter : MonoBehaviour
{
    [SerializeField] BaseRockThrowingSkill baseRockThrowing;

    public void ThrowRock()
    {
        Debug.Log("tr");
        baseRockThrowing.ThrowRock();
    }

    public void DoneThrowing() => baseRockThrowing.DoneThrowing();
}