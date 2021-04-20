using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimationController : MonoBehaviour
{
    Animator catAnimator = default;

    string attack = "Attack";
    string jump   = "Jump"  ;
    string die    = "Die"   ;
    string walk   = "Run"   ;
    string win    = "Win"   ;
    string idle   = "Idle"  ;

    void Start()
    {
        catAnimator = GetComponent<Animator>();
    }

    public void Walk()
    {
        catAnimator.SetBool(walk, true);
    }
    public void StopWalk() 
    {
        catAnimator.SetBool(walk, false);
    }
    public void Jump()
    {
        catAnimator.SetTrigger(jump);
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void Die()
    {
        catAnimator.SetTrigger(die);
    }
    public void Attack()
    {
        catAnimator.SetTrigger(attack);
    }
    public void Win()
    {
        catAnimator.SetTrigger(win);
    }
    public void Idle()
    {
        catAnimator.SetTrigger(idle);
    }
    public void SetSpeed(float speed=1)
    {
        if (speed > 0)
        {
            catAnimator.SetFloat("SpeedHandler", speed / 500);
            Walk();
        }
        else
        {
            Idle();
            StopWalk();
        }
    }
}
