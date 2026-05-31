using UnityEngine;

public class WeaponInjecter : MonoBehaviour
{
    [SerializeField] protected Transform theWaepon;
    [SerializeField] protected PlayerAttack playerAttack;
    internal AllWeaponMuzzle allWeaponMuzzle => transform.parent.GetComponentInChildren<AllWeaponMuzzle>();

    public void Start()
    {
        Setup(allWeaponMuzzle);
    }

    public virtual void Setup(AllWeaponMuzzle allWeaponPos)
    {
        //set weapon pos
        theWaepon.SetParent(allWeaponPos.HandR, false);
        playerAttack.rotateBody = allWeaponPos.transform;
    }
}
