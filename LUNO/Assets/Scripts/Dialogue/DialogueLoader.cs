using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;


public class DialogueLoader : MonoBehaviour
{
    [Serializable]
    public class Dialogue
    {
        public string dialogueName;
        public string charName;
        public int size;
        public string dialogue;
    }

    [Serializable]
    public class DialogueList
    {
        public Dialogue[] dialogues;
    }

    [SerializeField]
    private TextAsset dialogueJSON;

    private DialogueList dialogueList = new DialogueList();

    public Dialogue[] GetDialogues()
    {
        return dialogueList.dialogues;
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueList = JsonUtility.FromJson<DialogueList>(dialogueJSON.text);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
