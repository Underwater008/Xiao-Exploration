using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBoxController : MonoBehaviour
{
    private bool isOpen = false;         
    private bool isOpenFinished = false;  
    private bool isRewarded = false;      
    private const float speed = 2;
    private GameObject rewardWeapon;
    Vector3 leftEnd;
    Vector3 rightEnd;

    public GameObject[] weapons;
    private void Awake()
    {
        leftEnd = transform.GetChild(2).position - new Vector3(1, 0, 0);  
        rightEnd = transform.GetChild(3).position + new Vector3(1, 0, 0); 
    }
    private void Update()      
    {
        if(isOpen==true&&Vector3.Distance(transform.GetChild(2).position, leftEnd) > 0.01f && Vector3.Distance(transform.GetChild(3).position, rightEnd) > 0.01f)
        {
            transform.GetChild(2).position = Vector3.MoveTowards(transform.GetChild(2).position, leftEnd, speed*Time.deltaTime);
            transform.GetChild(3).position = Vector3.MoveTowards(transform.GetChild(3).position, rightEnd, speed*Time.deltaTime);
            if (Vector3.Distance(transform.GetChild(2).position, leftEnd) < 0.012f && Vector3.Distance(transform.GetChild(3).position, rightEnd) < 0.012f)
                isOpenFinished = true;
        }
        RewardWeapon();
        if (transform.GetChild(4).childCount!=0)  rewardWeapon= transform.GetChild(4).GetChild(0).gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)              
    {
        if(collision.CompareTag("Player")&&isOpen==false)
        {
            isOpen = true;
        }
    }

    void RewardWeapon()          
    {
        if (isOpenFinished == true && isRewarded == false)
        {
            int weaponIndex = Random.Range(0, weapons.Length);
            rewardWeapon=Instantiate(weapons[weaponIndex], transform.GetChild(4));
            isRewarded = true;
        }
    }

}
