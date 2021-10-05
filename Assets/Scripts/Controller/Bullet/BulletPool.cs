using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolAmount;          //To set in the editor
    public List<GameObject> bullets = new List<GameObject>();
    private int currentIndex=0;

    private void Start()
    {
        for(int i=0;i<poolAmount;i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            bullets.Add(obj);
        }
    }

    public GameObject GetBullet()
    {
        for(int i=0;i<bullets.Count;i++)
        {
            int tempIndex = (currentIndex + i) % bullets.Count;
            if(!bullets[tempIndex].activeInHierarchy)
            {
                currentIndex = (tempIndex+1) % bullets.Count;
                return bullets[tempIndex];
            }
        }
        GameObject obj = Instantiate(bulletPrefab);
        obj.transform.SetParent(transform);
        bullets.Add(obj);
        return obj;
    }
}
