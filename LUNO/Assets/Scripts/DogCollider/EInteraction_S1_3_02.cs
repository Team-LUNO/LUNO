using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EInteraction_S1_3_02 : MonoBehaviour
{
    public GameObject bubble;
    public GameObject info;
    public bool infoOnSwitch=false;
    public bool isUpperOn = false;


    void Start()
    {

    }

    void Update()
    {
        if(infoOnSwitch==true && Input.GetKeyDown(KeyCode.E))
        {
            if (bubble.activeSelf == true)
            {
                bubble.SetActive(false);
            }
            info = GameObject.FindWithTag("Obj").transform.GetChild(1).gameObject;
            info.transform.localPosition = new Vector3(0, 1.5f, 0);
            info.SetActive(true);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUpperOn==false & collision.gameObject.CompareTag("ObjLeft"))
        {
            //info ???????? ?????? ???? ???? 
            bubble = collision.gameObject.transform.parent.GetChild(0).gameObject;
            bubble.transform.localPosition = new Vector3(0, 1f, 0);
            bubble.GetComponent<SpriteRenderer>().color = Color.yellow;
            bubble.SetActive(true);
            infoOnSwitch = true;

        }

        if (collision.gameObject.CompareTag("ObjUpper"))
        {
            //info ???????? ?????? ???? ???? 
            bubble = collision.gameObject.transform.parent.GetChild(0).gameObject;
            bubble.transform.localPosition = new Vector3(0, 1f, 0);
            bubble.GetComponent<SpriteRenderer>().color = Color.blue;
            bubble.SetActive(true);
            isUpperOn = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }
}
