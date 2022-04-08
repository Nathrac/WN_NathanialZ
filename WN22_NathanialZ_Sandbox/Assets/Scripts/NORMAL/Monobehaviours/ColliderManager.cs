using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//On Empty in the hierarchy
public class ColliderManager : MonoBehaviour
{
    int hit;
    BoxCollider[] colliderArray; //fill array with the colliders for the weak points of the giant.

    //isStunnedScript

    private void Awake()
    {
        hit = 0;
    }

    public void CollideHit()//Function called in the toggle script to add to hit counter. after adding, check if counter is = 3 and if it is then activate isStunned bool
    {
        if (hit < 3)
        {
            hit++;
            if (hit == 3)
            {
                //reference isStunned script
                Debug.Log("isStunned = true");
            }
        }
        else 
        {
            return;
        }
    }

    //Call whenever isStunned is being set back to false
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
