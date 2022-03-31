using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimationSaving : MonoBehaviour
{
    public Animator animator;
    [SerializeField] string parameter;
    public TextMeshProUGUI tmp;
    int ss;

    public string sa;
    public int p;

    //set starting states of state machine which will use int values per function to determine when to change bool states. ss = start/stop c = character and o = object
    void Awake()
    {
        ss = 0;
        p = 1;
        sa = "";
       
    }

    public void AnimationTransition()
    {
        if (p == 1)
        {
            animator.SetBool(parameter, false);
            p = 0;
            sa = parameter + " false";
            tmp.text = sa;
        }
        else if (p == 0)
        {
            animator.SetBool(parameter, true);
            p = 1;
            sa = parameter + " true";
            tmp.text = sa;
        }
    }
   

    public void StartAnimation()
    {
        if (ss == 0)
        {
            animator.SetBool("isStarted", true);
            ss = 1;
        }
    }
    public void StopAnimation()
    {
        if (ss == 1)
        {
            animator.SetBool("isStarted", false);
            ss = 0;
        }
    }
    
    public void LoadA()
    {
        if (p == 1)
        {
            animator.SetBool(parameter, true);
        }
        else if (p == 0)
        {
            animator.SetBool(parameter, false);
        }
    }  
   
}
