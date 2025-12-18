using UnityEngine;
using TMPro;

public class DameText : MonoBehaviour
{
    [SerializeField] Vector3 offSet;
    [SerializeField] Camera cam;
    [SerializeField] TMP_Text theText;

    internal void SetPosition(Vector3 Pos)
    {
        Vector3 ScreenPos = cam.WorldToScreenPoint(Pos);
        transform.position = ScreenPos;
    }

    internal void SetText(string DameNumber)
    {
        theText.text = DameNumber;
    }
}