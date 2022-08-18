using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUpDetail : MonoBehaviour
{
    public GameObject[] sections;
    public GameObject[] details;
    Animator detailAnim;
    bool infoOnSwitch = false;
    int index;

    [SerializeField]
    private monologue mono;

    void Start()
    {


    }


    void Update()
    {
        if (index <2)
        {
            if (!details[index].activeSelf && infoOnSwitch == true && Input.GetKeyDown(KeyCode.E))
            {
                details[index].SetActive(true);
                infoOnSwitch = false;
                mono.limitMove(true);
            }
            else if (details[index].activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                detailAnim = details[index].GetComponent<Animator>();
                detailAnim.SetTrigger("PressE");
                StartCoroutine(DisappearDelay());
                mono.limitMove(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for(int i=0; i<sections.Length; i++)
        {
            if(collision.gameObject == sections[i])
            {
                infoOnSwitch = true;
                index = i;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < sections.Length; i++)
        {
            if (collision.gameObject == sections[i])
            {
                infoOnSwitch = false;
            }
        }
    }

    IEnumerator DisappearDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        details[index].SetActive(false);
        index = 0;
    }
}
