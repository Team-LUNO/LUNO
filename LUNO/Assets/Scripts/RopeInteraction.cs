using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopeInteraction : MonoBehaviour
{
    public GameObject rope;

    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rope") && !rope.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            rope.SetActive(true);
        }
    }
}
