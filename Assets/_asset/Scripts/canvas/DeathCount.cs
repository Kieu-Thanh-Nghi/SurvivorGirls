using TMPro;
using UnityEngine;

public class DeathCount : MonoBehaviour
{
    [SerializeField] TMP_Text killed;
    internal int counted = 0;

    private void Start()
    {
        killed.text = counted.ToString();
    }
    public void DoCount()
    {
        counted++;
        killed.text = counted.ToString();
    }
}
