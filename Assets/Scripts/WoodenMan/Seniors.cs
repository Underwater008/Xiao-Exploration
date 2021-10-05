using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seniors : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject finishPanel;
    private void Start()
    {
        dialogPanel.SetActive(false);
        finishPanel.SetActive(false);
        dialogPanel.gameObject.transform.parent.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && KeyCollision.isFinish == false)
        {
            dialogPanel.gameObject.transform.parent.gameObject.SetActive(true);
            dialogPanel.SetActive(true);
        }
        else if(collision.CompareTag("Player") && KeyCollision.isFinish == true)
        {
            dialogPanel.gameObject.transform.parent.gameObject.SetActive(true);
            finishPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogPanel.SetActive(false);
            finishPanel.SetActive(false);
            dialogPanel.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
