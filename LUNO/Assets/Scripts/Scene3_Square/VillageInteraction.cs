using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageInteraction : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.GetChild(0).gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.GetChild(0).gameObject.SetActive(false);
    }
}
