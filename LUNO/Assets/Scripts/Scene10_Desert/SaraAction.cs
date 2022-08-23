using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaraAction : MonoBehaviour
{
    [SerializeField]
    private PrologueManager prologueManager;
    public CameraController Camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sara"))
        {

            collision.gameObject.GetComponent<Animator>().SetBool("isWakeUp", true);
            StartCoroutine(Popup());
        }
    }

    IEnumerator Popup()
    {
        yield return new WaitForSeconds(3f);
        prologueManager.StartPrologue();
    }

   /* IEnumerator cameraMove()
    {
        Camera.Camera
    }*/
}
