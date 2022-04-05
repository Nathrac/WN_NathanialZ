using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponDescription : MonoBehaviour
{
    [SerializeField] GameObject weaponHowTo;
    [SerializeField] AudioSource weaponDescribe;

    public void DescribeWeapon()
    {
        weaponHowTo.SetActive(true);
        weaponDescribe.Play();
    }
}
