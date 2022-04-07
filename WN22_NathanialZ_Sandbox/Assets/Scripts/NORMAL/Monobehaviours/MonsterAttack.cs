using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    //[SerializeField] HealthBar hb;
    [SerializeField] int healthChange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //hb.RemoveHealth(healthChange);
        }
    }
}
