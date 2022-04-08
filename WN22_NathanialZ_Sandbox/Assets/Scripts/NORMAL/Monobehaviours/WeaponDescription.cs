using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add to GameEmpty for each weapon description, call function on weapon select
public class WeaponDescription : MonoBehaviour
{
    [SerializeField] GameObject weaponHowTo; //UI written element describing weapon if added
    [SerializeField] AudioSource weaponDescribe;

    bool descriptionPlayed;

    private void Awake()
    {
        descriptionPlayed = false;
    }
    //When each player grabs the weapon, if descriptionPlayed bool is flase, play description and how to use weapon on local client, then set to true so that each other time the player grabs the weapon, the function will not play.
    public void DescribeWeapon()
    {
       if (!descriptionPlayed)
        {
            weaponHowTo.SetActive(true);
            weaponDescribe.Play();
            descriptionPlayed = true;
        }
    }
}
