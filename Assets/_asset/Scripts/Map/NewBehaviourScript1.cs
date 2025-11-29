using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    [SerializeField] ParticleSystem[] ps;
    private void OnValidate()
    {
        ps = GetComponentsInChildren<ParticleSystem>();
    }

    private void Start()
    {
        foreach (var p in ps)
        {
            p.Stop();
        }
    }

    [ContextMenu("al")]
    void TurnOnAl()
    {
        foreach (var p in ps)
        {
            var main = p.main;
            main.cullingMode = ParticleSystemCullingMode.AlwaysSimulate;
        }
    }
    [ContextMenu("au")]
    void TurnOnAu()
    {
        foreach (var p in ps)
        {
            var main = p.main;
            main.cullingMode = ParticleSystemCullingMode.Automatic;
        }
    }

    [ContextMenu("pause")]
    void TurnOnPause()
    {
        foreach (var p in ps)
        {
            var main = p.main;
            main.cullingMode = ParticleSystemCullingMode.Pause;
        }
    }
}
