using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;   
    

    private void FixedUpdate()
    {
        if (target != null)
        {
            transform.LookAt(target); // Correction ici
        }
    }
}
