using UnityEngine;

public class SkinPreview : MonoBehaviour
{
    [SerializeField] Transform equippedSkin;
    internal Transform UnequippedPreviewSkin;
    [SerializeField] RuntimeAnimatorController skinPreviewAnimation;

    public void ChangeCurrentSkin(Transform newSkinPrefab, bool isEquipped = true)
    {
        var newSkin = Instantiate(newSkinPrefab, transform);
        newSkin.GetComponent<Animator>().runtimeAnimatorController = skinPreviewAnimation;
        ChangeSkin(ref GetNeededPreview(isEquipped), newSkin);
        RevealNeededSkin(isEquipped);
    }
    void ChangeSkin(ref Transform theSkin, Transform newSkin)
    {
        if (theSkin != null)
        {
            Destroy(theSkin.gameObject);
        }
        theSkin = newSkin;
    }
    ref Transform GetNeededPreview(bool isEquipped)
    {
        if (isEquipped)
        {
            return ref equippedSkin;
        }
        else
        {
            return ref UnequippedPreviewSkin;
        }
    }

    public void RevealNeededSkin(bool isEquipped)
    {
        if(UnequippedPreviewSkin != null)
        {
            UnequippedPreviewSkin.gameObject.SetActive(!isEquipped);
        }
        if(equippedSkin != null) equippedSkin.gameObject.SetActive(isEquipped);
    }
}