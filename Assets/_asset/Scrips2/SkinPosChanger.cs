using UnityEngine;

public class SkinPosChanger : MonoBehaviour
{
    [SerializeField] Transform skinPos, basePos;

    private void OnEnable()
    {
        ChangePos();
    }
    private void OnDisable()
    {
        ResetSkinPos();
    }
    public void ChangePos()
    {
        skinPos.position = transform.position;
    }
    public void ResetSkinPos()
    {
        skinPos.position = basePos.position;
    }
}