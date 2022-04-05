using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    int hit;
    BoxCollider[] colliderArray;

    private void Awake()
    {
        hit = 0;
    }

    public void CollideHit()
    {
        if (hit < 3)
        {
            hit++;
        }
        else if (hit == 3)
        {
            //reference myles isStunned Componenent and set it to true.
        }
    }

    public void ResetColliders()
    {
        if (hit == 3)
        {
            for (int i = 0; i < colliderArray.Length; i++)
            {
                if (!colliderArray[i].enabled)
                {
                    colliderArray[i].enabled = true;
                }
                else
                {
                    return;
                }
            }
        }
     }
}
