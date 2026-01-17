using UnityEngine;
using UnityEngine.Events;

public class EnemySkill : MonoBehaviour
{
    [SerializeField] internal float coolDown = 3;
    internal UnityAction DoWhenDone;
}
