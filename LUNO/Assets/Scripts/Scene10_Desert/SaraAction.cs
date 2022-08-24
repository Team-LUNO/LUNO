using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaraAction : MonoBehaviour
{
    [SerializeField]
    private PrologueManager prologueManager;
    public CameraController Camera;
    public Camera cam;
    //float smoothTime = 10f;    //목표도달까지 걸리는 시간
    //Vector3 moveVelocity = new Vector3(2.0f, 0, 0);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sara"))
        {
            Debug.Log("trigger");
            Debug.Log(cam.transform.position);
            StartCoroutine(cameraMove());
            collision.gameObject.GetComponent<Animator>().SetBool("isWakeUp", true);
            StartCoroutine(Popup());
        }
    }

    IEnumerator Popup()
    {
        yield return new WaitForSeconds(3f);
        prologueManager.StartPrologue();
    }

    IEnumerator cameraMove()
    {
        Camera.cameraMove = false;
        Debug.Log(cam.transform.localPosition);
        Vector3 targetPosition = new Vector3(cam.transform.localPosition.x + 10000000000000, cam.transform.localPosition.y, cam.transform.localPosition.z);
        cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, targetPosition,
                                               0.0000000000005f);
        Debug.Log(cam.transform.localPosition);
        yield return new WaitForSeconds(2f);

    }
}
