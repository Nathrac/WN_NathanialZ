using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantColliders : MonoBehaviour
{
    [SerializeField] string weaponTag;
    [SerializeField] BoxCollider colide;
       
    ShaderGlowToggle sgt;
    [SerializeField] ColliderManager cM;


    private void Awake()
    {
        sgt = GetComponent<ShaderGlowToggle>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(weaponTag))
        {
            sgt.SetShaderBool(false);
            cM.CollideHit();
        }
    }
}
