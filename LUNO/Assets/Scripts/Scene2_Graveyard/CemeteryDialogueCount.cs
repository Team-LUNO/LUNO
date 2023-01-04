using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemeteryDialogueCount : MonoBehaviour
{
    [SerializeField]
    private DialogueManager[] dialogueManagers1;

    [SerializeField]
    private DialogueManager[] dialogueManagers2;

    [SerializeField]
    private string dialogueName1;

    [SerializeField]
    private string dialogueName2;

    private int count = 0;

    public void IncreaseCount()
    {
        count++;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 3)
        {
            for(int i = 0; i < dialogueManagers1.Length; i++)
            {
                dialogueManagers1[i].dialogueName = dialogueName1;
                dialogueManagers2[i].dialogueName = dialogueName2;
            }
        }
    }
}
