using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

public class VATBaker : EditorWindow
{
    List<GameObject> targets = new List<GameObject>();
    List<AnimationClip> clips = new List<AnimationClip>();

    int fps = 30;

    GameObject resultContainer;
    Material material;
    string rootFolderName = "VAT";
    string posTexProperty = "_PosTex";
    string sourceMainTexProperty = "_MainTex";
    string targetMainTexProperty = "_MainTex";

    [MenuItem("Tools/VAT Baker (Ultimate)")]
    static void Open()
    {
        GetWindow<VATBaker>("VAT Baker");
    }

    void OnGUI()
    {
        GUILayout.Label("VAT Baker (Ultimate)", EditorStyles.boldLabel);

        // ===== Targets =====
        int targetCount = Mathf.Max(0, EditorGUILayout.IntField("Target Count", targets.Count));
        while (targetCount > targets.Count) targets.Add(null);
        while (targetCount < targets.Count) targets.RemoveAt(targets.Count - 1);

        for (int i = 0; i < targets.Count; i++)
        {
            targets[i] = (GameObject)EditorGUILayout.ObjectField($"Target {i}", targets[i], typeof(GameObject), true);
        }

        GUILayout.Space(10);

        // ===== Clips =====
        int clipCount = Mathf.Max(0, EditorGUILayout.IntField("Clip Count", clips.Count));
        while (clipCount > clips.Count) clips.Add(null);
        while (clipCount < clips.Count) clips.RemoveAt(clips.Count - 1);

        for (int i = 0; i < clips.Count; i++)
        {
            clips[i] = (AnimationClip)EditorGUILayout.ObjectField($"Clip {i}", clips[i], typeof(AnimationClip), false);
        }

        GUILayout.Space(10);

        fps = EditorGUILayout.IntField("FPS", fps);

        GUILayout.Space(10);

        resultContainer = (GameObject)EditorGUILayout.ObjectField("Result Container", resultContainer, typeof(GameObject), true);
        material = (Material)EditorGUILayout.ObjectField("Material", material, typeof(Material), false);
        rootFolderName = EditorGUILayout.TextField("Root Folder Name", rootFolderName);
        posTexProperty = EditorGUILayout.TextField("PosTex Property", posTexProperty);
        sourceMainTexProperty = EditorGUILayout.TextField("Source MainTex", sourceMainTexProperty);
        targetMainTexProperty = EditorGUILayout.TextField("Target MainTex", targetMainTexProperty);

        GUILayout.Space(10);

        if (GUILayout.Button("Bake & Create Objects"))
        {
            BakeAll();
        }
    }

    void BakeAll()
    {
        if (targets.Count == 0 || clips.Count == 0 || material == null || resultContainer == null)
        {
            Debug.LogError("Thiếu input!");
            return;
        }

        foreach (var target in targets)
        {
            if (target == null) continue;
            BakeTarget(target);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("🔥 DONE!");
    }

    void BakeTarget(GameObject target)
    {
        var smr = target.GetComponentInChildren<SkinnedMeshRenderer>();
        if (smr == null)
        {
            Debug.LogWarning($"[{target.name}] Không có SkinnedMeshRenderer");
            return;
        }

        Mesh sourceMesh = smr.sharedMesh;
        int vertexCount = sourceMesh.vertexCount;

        // ===== Folder =====
        string root = $"Assets/{rootFolderName}";
        if (!AssetDatabase.IsValidFolder(root))
            AssetDatabase.CreateFolder("Assets", rootFolderName);

        string objFolder = $"{root}/{target.name}";
        if (!AssetDatabase.IsValidFolder(objFolder))
            AssetDatabase.CreateFolder(root, target.name);

        // ===== Mesh =====
        string meshPath = $"{objFolder}/{sourceMesh.name}_VAT.asset";
        Mesh vatMesh;

        if (File.Exists(meshPath))
        {
            vatMesh = AssetDatabase.LoadAssetAtPath<Mesh>(meshPath);
        }
        else
        {
            vatMesh = Instantiate(sourceMesh);
            vatMesh.name = sourceMesh.name + "_VAT";

            Vector2[] uv2 = new Vector2[vertexCount];
            for (int i = 0; i < vertexCount; i++)
                uv2[i] = new Vector2(i / (float)(vertexCount - 1), 0);

            vatMesh.uv2 = uv2;

            AssetDatabase.CreateAsset(vatMesh, meshPath);
        }

        // ===== Anim Data =====
        var animData = ScriptableObject.CreateInstance<VATAnimData>();

        int totalFrames = 0;

        foreach (var clip in clips)
        {
            if (clip == null) continue;

            int frameCount = Mathf.CeilToInt(clip.length * fps);

            animData.names.Add(clip.name);
            animData.startFrames.Add(totalFrames);
            animData.frameCounts.Add(frameCount);

            totalFrames += frameCount;
        }

        animData.totalFrames = totalFrames;

        // ===== Texture =====
        Texture2D posTex = new Texture2D(vertexCount, totalFrames, TextureFormat.RGBAFloat, false, true);
        posTex.name = $"{target.name}_VAT_PosTex";
        posTex.filterMode = FilterMode.Point;
        posTex.wrapMode = TextureWrapMode.Clamp;

        Mesh bakedMesh = new Mesh();
        int globalFrame = 0;

        foreach (var clip in clips)
        {
            if (clip == null) continue;

            int frameCount = Mathf.CeilToInt(clip.length * fps);

            for (int f = 0; f < frameCount; f++)
            {
                float time = f / (float)fps;

                clip.SampleAnimation(target, time);
                smr.BakeMesh(bakedMesh);

                var vertices = bakedMesh.vertices;

                for (int v = 0; v < vertexCount; v++)
                {
                    Vector3 pos = vertices[v];
                    posTex.SetPixel(v, globalFrame, new Color(pos.x, pos.y, pos.z, 1));
                }

                globalFrame++;
            }
        }

        posTex.Apply();

        // reset animation
        if (clips[0] != null)
            clips[0].SampleAnimation(target, 0f);

        // ===== Save =====
        string texPath = $"{objFolder}/{posTex.name}.asset";
        string dataPath = $"{objFolder}/AnimData.asset";

        if (File.Exists(texPath)) AssetDatabase.DeleteAsset(texPath);
        if (File.Exists(dataPath)) AssetDatabase.DeleteAsset(dataPath);

        AssetDatabase.CreateAsset(posTex, texPath);
        //AssetDatabase.CreateAsset(animData, dataPath);

        // ===== CREATE RESULT OBJECT =====
        GameObject newObj = new GameObject(target.name + "_VAT");
        newObj.transform.SetParent(resultContainer.transform);
        newObj.transform.position = Vector3.zero;
        newObj.transform.rotation = target.transform.rotation;
        newObj.transform.localScale = target.transform.localScale;

        // MeshFilter + MeshRenderer
        var mf = newObj.AddComponent<MeshFilter>();
        var mr = newObj.AddComponent<MeshRenderer>();
        var vp = newObj.AddComponent<VATPlayer>();

        mf.sharedMesh = vatMesh;
        //vp.data = animData;
        vp.totalFrames = animData.totalFrames;

        // ===== CREATE MATERIAL INSTANCE =====
        Material newMat = new Material(material);
        newMat.name = material.name + "_" + target.name;

        string matPath = $"{objFolder}/{newMat.name}.asset";
        if (File.Exists(matPath)) AssetDatabase.DeleteAsset(matPath);
        AssetDatabase.CreateAsset(newMat, matPath);

        // gán PosTex
        if (newMat.HasProperty(posTexProperty))
        {
            newMat.SetTexture(posTexProperty, posTex);
        }
        else
        {
            Debug.LogWarning($"Material không có property: {posTexProperty}");
        }

        var oldMat = smr.sharedMaterial;
        // copy MainTex từ material gốc
        if (oldMat.HasProperty(sourceMainTexProperty) && newMat.HasProperty(targetMainTexProperty))
        {
            Texture mainTex = oldMat.GetTexture(sourceMainTexProperty);
            newMat.SetTexture(targetMainTexProperty, mainTex);
        }

        // gán material
        mr.sharedMaterial = newMat;
        Debug.Log($"✔ Created VAT Object: {newObj.name}");
    }
}
//public class VATBaker : EditorWindow
//{
//    string save_name = "Assets/VAT";
//    List<GameObject> targets = new List<GameObject>();
//    List<AnimationClip> clips = new List<AnimationClip>();
//    int fps = 30;

//    [MenuItem("Tools/VAT Baker (Multi Anim)")]
//    static void Open()
//    {
//        GetWindow<VATBaker>("VAT Baker");
//    }

//    void OnGUI()
//    {
//        GUILayout.Label("VAT Baker (Multi Object + Multi Anim)", EditorStyles.boldLabel);
//        save_name = EditorGUILayout.TextField("Save Name", save_name);
//        // ===== Targets =====
//        int targetCount = Mathf.Max(0, EditorGUILayout.IntField("Target Count", targets.Count));
//        while (targetCount > targets.Count) targets.Add(null);
//        while (targetCount < targets.Count) targets.RemoveAt(targets.Count - 1);

//        for (int i = 0; i < targets.Count; i++)
//        {
//            targets[i] = (GameObject)EditorGUILayout.ObjectField($"Target {i}", targets[i], typeof(GameObject), true);
//        }

//        GUILayout.Space(10);

//        // ===== Clips =====
//        int clipCount = Mathf.Max(0, EditorGUILayout.IntField("Clip Count", clips.Count));
//        while (clipCount > clips.Count) clips.Add(null);
//        while (clipCount < clips.Count) clips.RemoveAt(clips.Count - 1);

//        for (int i = 0; i < clips.Count; i++)
//        {
//            clips[i] = (AnimationClip)EditorGUILayout.ObjectField($"Clip {i}", clips[i], typeof(AnimationClip), false);
//        }

//        GUILayout.Space(10);

//        fps = EditorGUILayout.IntField("FPS", fps);

//        if (GUILayout.Button("Bake ALL"))
//        {
//            BakeAll();
//        }
//    }

//    void BakeAll()
//    {
//        if (targets.Count == 0 || clips.Count == 0)
//        {
//            Debug.LogError("Thiếu target hoặc animation clip");
//            return;
//        }

//        foreach (var target in targets)
//        {
//            if (target == null) continue;

//            foreach (var clip in clips)
//            {
//                if (clip == null) continue;

//                BakeSingle(target, clip);
//            }
//        }

//        AssetDatabase.SaveAssets();
//        AssetDatabase.Refresh();

//        Debug.Log("🔥 Bake ALL xong!");
//    }

//    void BakeSingle(GameObject target, AnimationClip clip)
//    {
//        var smr = target.GetComponentInChildren<SkinnedMeshRenderer>();
//        if (smr == null)
//        {
//            Debug.LogWarning($"[{target.name}] Không có SkinnedMeshRenderer");
//            return;
//        }

//        Mesh sourceMesh = smr.sharedMesh;
//        int vertexCount = sourceMesh.vertexCount;

//        // ===== Folder =====
//        string rootFolder = save_name;

//        // tạo folder gốc nếu chưa có
//        if (!Directory.Exists(rootFolder))
//            Directory.CreateDirectory(rootFolder);

//        string objectFolder = $"{rootFolder}/{target.name}";
//        if (!AssetDatabase.IsValidFolder(objectFolder))
//            AssetDatabase.CreateFolder(rootFolder, target.name);

//        // ===== Mesh (chỉ tạo 1 lần nếu chưa có) =====
//        string meshPath = $"{objectFolder}/{sourceMesh.name}_VAT.asset";
//        Mesh vatMesh;

//        if (File.Exists(meshPath))
//        {
//            vatMesh = AssetDatabase.LoadAssetAtPath<Mesh>(meshPath);
//        }
//        else
//        {
//            vatMesh = Instantiate(sourceMesh);
//            vatMesh.name = sourceMesh.name + "_VAT";

//            Vector2[] uv2 = new Vector2[vertexCount];
//            for (int i = 0; i < vertexCount; i++)
//            {
//                uv2[i] = new Vector2(i / (float)(vertexCount - 1), 0);
//            }
//            vatMesh.uv2 = uv2;

//            AssetDatabase.CreateAsset(vatMesh, meshPath);
//        }

//        // ===== Bake animation =====
//        int totalFrames = Mathf.CeilToInt(clip.length * fps);

//        Texture2D posTex = new Texture2D(vertexCount, totalFrames, TextureFormat.RGBAFloat, false, true);
//        posTex.name = $"{clip.name}_PosTex";
//        posTex.filterMode = FilterMode.Point;
//        posTex.wrapMode = TextureWrapMode.Clamp;

//        Mesh bakedMesh = new Mesh();

//        for (int f = 0; f < totalFrames; f++)
//        {
//            float time = f / (float)fps;

//            clip.SampleAnimation(target, time);
//            smr.BakeMesh(bakedMesh);

//            var vertices = bakedMesh.vertices;

//            for (int v = 0; v < vertexCount; v++)
//            {
//                Vector3 pos = vertices[v];
//                posTex.SetPixel(v, f, new Color(pos.x, pos.y, pos.z, 1));
//            }
//        }

//        posTex.Apply();

//        // ===== Save texture =====
//        string texPath = $"{objectFolder}/{clip.name}_PosTex.asset";

//        if (File.Exists(texPath))
//            AssetDatabase.DeleteAsset(texPath);

//        AssetDatabase.CreateAsset(posTex, texPath);

//        Debug.Log($"✔ [{target.name}] - [{clip.name}] Bake xong!");

//        // reset animation về frame đầu
//        clip.SampleAnimation(target, 0f);
//    }
//}

//using UnityEngine;
//using UnityEditor;
//using System.IO;

//public class VATBaker : EditorWindow
//{
//    GameObject target;
//    AnimationClip clip;
//    int fps = 30;

//    [MenuItem("Tools/VAT Baker (Full)")]
//    static void Open()
//    {
//        GetWindow<VATBaker>("VAT Baker");
//    }

//    void OnGUI()
//    {
//        GUILayout.Label("VAT Baker", EditorStyles.boldLabel);

//        target = (GameObject)EditorGUILayout.ObjectField("Target", target, typeof(GameObject), true);
//        clip = (AnimationClip)EditorGUILayout.ObjectField("Animation Clip", clip, typeof(AnimationClip), false);
//        fps = EditorGUILayout.IntField("FPS", fps);

//        if (GUILayout.Button("Bake VAT"))
//        {
//            Bake();
//        }
//    }

//    void Bake()
//    {
//        if (target == null || clip == null)
//        {
//            Debug.LogError("Thiếu target hoặc clip");
//            return;
//        }

//        var smr = target.GetComponentInChildren<SkinnedMeshRenderer>();
//        if (smr == null)
//        {
//            Debug.LogError("Không tìm thấy SkinnedMeshRenderer");
//            return;
//        }

//        // =========================
//        // 1. Clone mesh + UV2
//        // =========================
//        Mesh sourceMesh = smr.sharedMesh;
//        int vertexCount = sourceMesh.vertexCount;

//        Mesh vatMesh = Instantiate(sourceMesh);
//        vatMesh.name = sourceMesh.name + "_VAT";

//        Vector2[] uv2 = new Vector2[vertexCount];

//        for (int i = 0; i < vertexCount; i++)
//        {
//            uv2[i] = new Vector2(i / (float)(vertexCount - 1), 0);
//        }

//        vatMesh.uv2 = uv2;

//        // =========================
//        // 2. Bake animation → texture
//        // =========================
//        int totalFrames = Mathf.CeilToInt(clip.length * fps);

//        Texture2D posTex = new Texture2D(vertexCount, totalFrames, TextureFormat.RGBAFloat, false, true);
//        posTex.name = clip.name + "_PosTex";
//        posTex.filterMode = FilterMode.Point;
//        posTex.wrapMode = TextureWrapMode.Clamp;

//        Mesh bakedMesh = new Mesh();

//        for (int f = 0; f < totalFrames; f++)
//        {
//            float time = f / (float)fps;

//            clip.SampleAnimation(target, time);
//            smr.BakeMesh(bakedMesh);

//            Vector3[] vertices = bakedMesh.vertices;

//            for (int v = 0; v < vertexCount; v++)
//            {
//                Vector3 pos = vertices[v];
//                posTex.SetPixel(v, f, new Color(pos.x, pos.y, pos.z, 1));
//            }
//        }

//        posTex.Apply();

//        // =========================
//        // 3. Save assets
//        // =========================
//        string folder = "Assets/VAT";
//        if (!Directory.Exists(folder))
//            Directory.CreateDirectory(folder);

//        string meshPath = $"{folder}/{vatMesh.name} .asset";
//        string texPath = $"{folder}/{posTex.name} {vatMesh.name}.asset";

//        AssetDatabase.CreateAsset(vatMesh, meshPath);
//        AssetDatabase.CreateAsset(posTex, texPath);

//        AssetDatabase.SaveAssets();
//        AssetDatabase.Refresh();

//        Debug.Log($"VAT Bake xong!\nMesh: {meshPath}\nTexture: {texPath}\nFrames: {totalFrames}");
//    }
//}