using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField]GameObject confetti;

    private void OnTriggerEnter(Collider other)
    {     
        if (other.CompareTag("Player"))
        {  
           other.transform.position = new Vector3(
                0,
                other.transform.position.y ,
                other.transform.position.z);


            other.GetComponent<SizeChanger>().canLoseWeight = false;
            other.GetComponent<PlayerController2>().jumping = true;
            other.GetComponent<AnimationController>().Jump();
            confetti.SetActive(true);
            Camera.main.GetComponent<AudioSource>().Stop();
        }
    }
}
