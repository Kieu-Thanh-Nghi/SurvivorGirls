using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    internal static PlayerDataManager Instance;

    [SerializeField] internal float baseSpeed = 5;
    internal float _moveSpeedScale = 1;
    internal float _objectSpeedScale = 1;
    internal float _areaRadiusScale = 1;
    internal float _ASCoolDownScale = 1;
    internal float _activeDuration = 1;
    internal float _gotExpScale = 1;
    internal float _damage = 1;
    internal float _reloadTime = 1;
    internal float _reloadPadding = 0;

    internal float MoveSpeed => baseSpeed * _moveSpeedScale;
    private void Awake()
    {
        Instance = this;
    }
}