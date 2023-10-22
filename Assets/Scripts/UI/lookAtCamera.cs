using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCamera : MonoBehaviour
{
    [SerializeField] Camera camera;
    void Update()
    {
        transform.LookAt(camera.transform);
    }
}
