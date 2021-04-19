using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterScript : MonoBehaviour
{
    [SerializeField]
    GroundMover groundMover;

    void Awake()
    {
        groundMover.enabled = false;
        GetComponent<SizeChanger>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AnimationController>().Walk();
            groundMover.enabled = true;
            GetComponent<SizeChanger>().enabled = true;
        }
    }
}
