using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollision : MonoBehaviour
{
    public static bool isFinish = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Congratulations
            isFinish = true;
            this.gameObject.SetActive(false);
        }
    }
}
