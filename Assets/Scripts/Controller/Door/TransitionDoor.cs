using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionDoor : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&&Input.GetKeyDown(KeyCode.Space))
        {
            //Congratulations
            SceneManager.LoadScene(2);
        }
    }
}
