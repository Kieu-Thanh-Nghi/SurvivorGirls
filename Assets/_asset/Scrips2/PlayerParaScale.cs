using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParaScale : MonoBehaviour, IProjectileSpeedScale, IAreaRadiusScale
{
    internal static PlayerParaScale Instance;

    [SerializeField] internal float _moveSpeed = 1;
    [SerializeField] internal float _objectProjectileSpeed = 1;
    [SerializeField] internal float _areaRadius = 1;
    [SerializeField] internal float _coolDown = 1;
    [SerializeField] internal float _activeDuration = 1;
    [SerializeField] internal float _gotExp = 1;
    [SerializeField] internal float _damage = 1;
    [SerializeField] internal float _reloadTime = 1;

    private void Awake()
    {
        Instance = this;
    }
    public float ObjectProjectileSpeed 
    { 
        get => _objectProjectileSpeed; 
        set => _objectProjectileSpeed = value; 
    }
    public float AreaRadius
    {
        get => _areaRadius;
        set => _areaRadius = value;
    }
}

public interface IProjectileSpeedScale
{
    public float ObjectProjectileSpeed { get; set; }
}
public interface IAreaRadiusScale
{
    public float AreaRadius { get; set; }
}
