using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] Transform cam;
    [ContextMenu("look")]
    void LookAtCam()
    {
        transform.rotation = cam.rotation;
        //transform.forward = cam.forward;
        //transform.right = cam.right;
    }
}
