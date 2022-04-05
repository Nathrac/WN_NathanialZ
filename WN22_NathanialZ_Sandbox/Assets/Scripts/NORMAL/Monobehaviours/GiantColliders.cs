using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantColliders : MonoBehaviour
{
    [SerializeField] string weaponTag;

    ShaderGlowToggle sgt;

    private void Awake()
    {
        sgt = GetComponent<ShaderGlowToggle>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(weaponTag))
        {
            sgt.SetShaderBool(true);
        }
    }
}
