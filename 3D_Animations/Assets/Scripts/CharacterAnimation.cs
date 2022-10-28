using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
   public Animator animator;
    public MovePerson movePerson;
    public CharacterStatus characterStatus;
    public void UpdateAnimation()
    {
        animator.SetBool("sprint", characterStatus.isSprint);
        animator.SetBool("aiming", characterStatus.isAiming);

        if(!characterStatus.isAiming)
        {
            AnimationNormal();
        }
        else
        {
            AnimationAiming();
        }
    }

    void AnimationNormal()
    {
        animator.SetFloat("vertical", movePerson.moveAmount, 0.15f, Time.deltaTime);
    }

    void AnimationAiming()
    {
        float ver = movePerson.vertical;
        float hor = movePerson.horizontal;

        animator.SetFloat("vertical", ver, 0.15f, Time.deltaTime);
        animator.SetFloat("horizontal", hor, 0.15f, Time.deltaTime);
    }

    
}
