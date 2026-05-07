using UnityEngine;
using UnityEditor;
using System.IO;

public class BakeSkinnedMeshToAssets
{
    [MenuItem("Tools/Bake Skinned Mesh Animation")]
    static void Bake()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj == null)
        {
            Debug.LogError("Chọn object có SkinnedMeshRenderer");
            return;
        }

        var smr = obj.GetComponentInChildren<SkinnedMeshRenderer>();
        var animator = obj.GetComponent<Animator>();

        if (smr == null || animator == null)
        {
            Debug.LogError("Thiếu SkinnedMeshRenderer hoặc Animator");
            return;
        }

        AnimationClip clip = animator.runtimeAnimatorController.animationClips[0];

        string folder = "Assets/BakedMeshes";
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        int frameRate = 30;
        int totalFrames = Mathf.CeilToInt(clip.length * frameRate);

        for (int i = 0; i < totalFrames; i++)
        {
            float time = i / (float)frameRate;

            clip.SampleAnimation(obj, time);

            Mesh mesh = new Mesh();
            smr.BakeMesh(mesh);

            string path = $"{folder}/{clip.name}_frame_{i}.asset";
            AssetDatabase.CreateAsset(mesh, path);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log($"Bake xong {totalFrames} frames vào {folder}");
    }
}