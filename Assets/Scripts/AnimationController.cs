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

    void Start()
    {
        catAnimator = GetComponent<Animator>();
    }

    public void Walk()
    {
        catAnimator.SetBool(walk, true);
    }
    public void Jump()
    {
        catAnimator.SetTrigger(jump);
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
}
