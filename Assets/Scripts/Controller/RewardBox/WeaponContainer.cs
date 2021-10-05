using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponContainer : MonoBehaviour
{
    private GameObject weaponInfoText;

    private void Awake()
    {
        weaponInfoText = transform.parent.GetChild(5).GetChild(0).gameObject;
    }
    private void Update()
    {
        DestroyWeapon();
        SetRewardTextPos();
    }
    void DestroyWeapon()
    {
        if (transform.childCount > 1)
        {
            transform.GetChild(1).SetSiblingIndex(0);   
            for (int i = 1; i < transform.childCount; i++)  
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    void SetRewardTextPos()
    {
        if (transform.childCount != 0)
        {
            Vector3 rewardTextPos = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 2f, 0));
            weaponInfoText.transform.position = rewardTextPos;
            weaponInfoText.GetComponent<Text>().text = transform.GetChild(0).GetComponent<WeaponController>().weaponData.weaponName;
            switch(transform.GetChild(0).GetComponent<WeaponController>().weaponData.weaponLevel)
            {
                case WeaponLevel.NORMAL:     
                    weaponInfoText.GetComponent<Text>().color = Color.white;
                    break;
                case WeaponLevel.GOOD:     
                    weaponInfoText.GetComponent<Text>().color = Color.green;
                    break;
                case WeaponLevel.RARE:      
                    weaponInfoText.GetComponent<Text>().color = Color.blue;
                    break;
                case WeaponLevel.EPIC:      
                    weaponInfoText.GetComponent<Text>().color = new Color32(255, 0, 255, 255);  
                    break;
                case WeaponLevel.LEGEND:   
                    weaponInfoText.GetComponent<Text>().color = Color.yellow;
                    break;
            }
            weaponInfoText.SetActive(true);
        }
    }
}
