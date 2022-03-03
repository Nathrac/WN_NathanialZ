using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggerPractice : MonoBehaviour
{
    public Animator animator;
    public GameObject sphere;
    [SerializeField] string paramater;
   
    // Update is called once per frame
    void Update()
    {
        StaticAnimator();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AnimationTransition();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            sphere.isStatic = false;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            sphere.isStatic = true;
        }
  
    }

    public void AnimationTransition()
    {
        if (!animator.GetBool(paramater))
        {
            animator.SetBool(paramater, true);
            animator.speed = 2;
        }
        else
        {
            animator.SetBool(paramater, false);
            animator.speed = 0.5f;
        }
    }

    public void StaticAnimator()
    {
        if (sphere.isStatic)
        {
            animator.enabled = false;
        }
        else
        {
            animator.enabled = true;
        }
    }

}
