using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour  
{
    private GameObject weaponOnHand;  
    private PlayerStats playerStats;
    private void Awake()
    {
        weaponOnHand = GetComponent<WeaponController>().weaponData.weaponPrefab;
    }

    private void Start()   
    {
        playerStats = GameManager.Instance.playerStats;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (playerStats.isSecondWeapon == false)
            {
                Instantiate(playerStats.mainWeapon.GetComponent<WeaponController>().weaponData.weaponOnGroundPrefab, transform.parent); 
                playerStats.mainWeapon = weaponOnHand;                 
                Destroy(playerStats.weaponPos.GetChild(0).gameObject);
            }         
            else
            {
                Instantiate(playerStats.secondWeapon.GetComponent<WeaponController>().weaponData.weaponOnGroundPrefab, transform.parent); 
                playerStats.secondWeapon = weaponOnHand;                  
                Destroy(playerStats.weaponPos.GetChild(0).gameObject);
            }
        }
    }
}
