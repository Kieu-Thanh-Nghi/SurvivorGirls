using UnityEngine;

[CreateAssetMenu(menuName = "SelectTabSize")]
public class SelectTabSize : ScriptableObject
{
    [SerializeField] internal float MinX = -13.5f;
    [SerializeField] internal float MaxX = 13.5f;
    [SerializeField] internal float MaxY = 28.5f;
}