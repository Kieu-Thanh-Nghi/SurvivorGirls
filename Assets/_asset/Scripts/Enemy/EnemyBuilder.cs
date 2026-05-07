using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder : MonoBehaviour
{
    [SerializeField] Transform EnemyType;
    [SerializeField] List<GameObject> EnemyBodies;

    [ContextMenu("build vat")]
    void VATBuild()
    {
        foreach (var e in EnemyBodies)
        {
            var newEne = Instantiate(EnemyType, transform);
            newEne.GetComponentInChildren<MeshFilter>().sharedMesh = e.GetComponent<MeshFilter>().sharedMesh;
            newEne.GetComponentInChildren<Renderer>().sharedMaterial = e.GetComponent<Renderer>().sharedMaterial;
            newEne.name = e.name + "done";
        }
    }    
    
    [ContextMenu("build normal")]
    void Build()
    {
        foreach (var e in EnemyBodies)
        {
            var newEne = Instantiate(EnemyType, transform);
            newEne.GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh = e.GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh;
            newEne.GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterial = e.GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterial;
            newEne.name = e.name + "done";
        }
    }

    [SerializeField] List<GameObject> EnemyDones;
    [ContextMenu("ChangeNames")]
    void ChangeNames()
    {
        int n = EnemyDones.Count;
        for(int i = 0; i < n; i++)
        {
            EnemyDones[i].name = EnemyBodies[i].name + " done";
        }
    }
}
