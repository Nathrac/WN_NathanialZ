using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Put on minions
public class MonsterAttack : MonoBehaviour
{
    [SerializeField] HealthBar hb;
    [SerializeField] float healthChange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hb.RemoveHealth(healthChange); //when minion hits player remove from their health
        }
    }
}
