using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Put on enemys 
public class MonsterAttack : MonoBehaviour
{
    HealthBar hb;
    [SerializeField] float removeHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit");
            hb = other.GetComponent<HealthBar>();
            hb.RemoveHealth(removeHealth); //when enemy hits player remove from their health
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit");
            hb = collision.gameObject.GetComponent<HealthBar>();
            hb.RemoveHealth(removeHealth); //when enemy hits player remove from their health
        }
    }
}
