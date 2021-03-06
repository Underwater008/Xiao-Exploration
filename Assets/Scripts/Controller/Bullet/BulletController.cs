using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public bool isActive=false;
    public Rigidbody2D rb;
    public WeaponData_SO weaponData;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

    }

    

    private void OnTriggerEnter2D(Collider2D collision)   
    {
        if(CompareTag("PlayerBullet")&&collision.CompareTag("Enemy"))   
        {
            collision.gameObject.GetComponent<EnemyStats>().TakeDamage(weaponData);
            gameObject.SetActive(false);
            isActive = false;
        }
        else if(CompareTag("PlayerBullet") && collision.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<BossStats>().TakeDamage(weaponData);
            gameObject.SetActive(false);
            isActive = false;
        }
        else if(collision.CompareTag("Border"))
        {
            gameObject.SetActive(false);
            isActive = false;
        }
        else if(CompareTag("EnemyBullet")&&collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(weaponData);
            gameObject.SetActive(false);
            isActive = false;
        }
    }
}
