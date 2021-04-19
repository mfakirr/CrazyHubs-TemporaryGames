using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 0;

    private void FixedUpdate()
    {
        transform.RotateAround(transform.position, 
                               Vector3.up, 
                               rotateSpeed * Time.fixedDeltaTime);
    }
}
