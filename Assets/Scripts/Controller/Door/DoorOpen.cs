using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject doorClosed;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.isPlayerInMainRoom = true;
            gameObject.SetActive(false);
            doorClosed.SetActive(true);
        }
    }
}
