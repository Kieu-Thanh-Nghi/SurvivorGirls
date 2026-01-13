using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class BulletQuantity : MonoBehaviour
{
    [SerializeField] int quantity;
    [SerializeField] Image reloadImage;
    [SerializeField] TMP_Text quantityText;
    [SerializeField] float reloadTime;
    internal float ReloadTime
    {
        get
        {
            float theReloadTime = Mathf.CeilToInt((reloadTime + PlayerParaScale.Instance._reloadPadding) * PlayerParaScale.Instance._reloadTime);
            if (theReloadTime <= 0) theReloadTime = 0.1f;
            return theReloadTime;
        }
    }
    int currentQuantity;

    private void Start()
    {
        resetQuantity();
    }

    [ContextMenu("Decrease")]
    void Test()
    {
        IGunLockable testG = new TestGun();
        DecreaseBullet(testG);
    }
    public void DecreaseBullet(IGunLockable gun)
    {
        currentQuantity--;
        quantityText.text = currentQuantity.ToString();
        if (currentQuantity < 1)
        {
            gun.SetLockGun(true);
            StartCoroutine(Reload(gun));
        }
    }

    IEnumerator Reload(IGunLockable gun)
    {
        reloadImage.enabled = true;
        float startTime = Time.time;
        yield return new WaitUntil(() => ReloadEff(startTime));
        reloadImage.enabled = false;
        resetQuantity();
        gun.SetLockGun(false);
    }
    bool ReloadEff(float startTime)
    {
        float percent = (Time.time - startTime) / ReloadTime;
        reloadImage.fillAmount = 1 - percent;

        return percent >= 1;
    }
    internal void resetQuantity()
    {
        currentQuantity = quantity;
        quantityText.text = quantity.ToString();
    }
}

public interface IGunLockable
{
    void SetLockGun(bool isLock);
}

public class TestGun : IGunLockable
{
    public void SetLockGun(bool isLock)
    {
        
    }
}
