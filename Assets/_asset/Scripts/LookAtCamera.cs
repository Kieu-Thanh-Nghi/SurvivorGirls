using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] Transform cam;

    private void OnEnable()
    {
        LookAtCam();
    }
    [ContextMenu("look")]
    void LookAtCam()
    {
        cam = Camera.main.transform;
        transform.rotation = cam.rotation;
        //transform.forward = cam.forward;
        //transform.right = cam.right;
    }
}
