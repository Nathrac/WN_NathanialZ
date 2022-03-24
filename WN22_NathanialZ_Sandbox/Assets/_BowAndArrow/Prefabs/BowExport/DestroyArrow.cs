using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArrow : MonoBehaviour
{
    [SerializeField]
    float lifeSpan = 1.5f;
    void Update()
    {
        if (lifeSpan >= 0)
        {
            lifeSpan -= Time.deltaTime;                       //counts/checks lifespan left
        }
        else
        {
            Destroy(gameObject);                      //destroys game object after lifespan 
        }
    }
}
