using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterInputs")]
public class CharacterData : ScriptableObject
{
    [SerializeField] internal float moveSpeed;
    [SerializeField] internal float runSpeed;
}