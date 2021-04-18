using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    Rigidbody body;
    public float speed;
    public bool doMove;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(doMove)
            body.velocity = Vector3.back * speed * Time.deltaTime;
    }
}
