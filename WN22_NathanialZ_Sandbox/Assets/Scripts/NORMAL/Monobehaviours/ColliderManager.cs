using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    int hit;
    BoxCollider[] colliderArray;

    //isStunnedScript

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

    public void ResetColliders() //reset hit counter to 0 and reset collider array by going through the array and setting all disabled colliders to enabled.
    {
        if (hit == 3)
        {
            hit = 0;
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
