using UnityEngine;

public class AnimThrowingAdapter : MonoBehaviour
{
    [SerializeField] BaseRockThrowingSkill baseRockThrowing;

    public void ThrowRock() => baseRockThrowing.ThrowRock();

    public void DoneThrowing() => baseRockThrowing.DoneThrowing();
}