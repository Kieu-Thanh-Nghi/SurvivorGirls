using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShopProduct : MonoBehaviour
{
    [SerializeField] internal int ProductAmount;

    public abstract void AchiveProduct();

    public virtual Sprite GetIcon() { return null; }
}

public abstract class PurchaseButton : MonoBehaviour
{
    public abstract void PayThePrice();
}
