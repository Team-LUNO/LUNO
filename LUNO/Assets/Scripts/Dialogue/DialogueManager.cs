using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private DialogueLoader dialogueLoader;

    [SerializeField]
    private string dialogueName;

    private DialogueLoader.Dialogue[] dialogues;

    private int order = 0;
    private GameObject frontBubble;
    private GameObject backBubble;
    private GameObject selectionBubble;
    private bool firstPlay = true;
    private bool typeDone = false;
    private bool isDone = false;

    private bool start = false;

    public void StartDialogue()
    {
        start = true;
    }

    public void IncreaseOrder()
    {
        order++;
        firstPlay = true;
        typeDone = false;
    }

    public bool GetDone()
    {
        return isDone;
    }

    public void ResetOrder()
    {
        order = 0;
        isDone = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogues = dialogueLoader.GetDialogues();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogues == null)
        {
            dialogues = dialogueLoader.GetDialogues();
        }
        else {
            if (start && !isDone)
            {
                if (order < dialogues.Length)
                {
                    if (dialogues[order].dialogueName == dialogueName)
                    {
                        if (order == 0)
                        {
                            if (firstPlay)
                            {
                                firstPlay = false;

                                frontBubble = GameObject.Find(dialogues[order].charName).transform.Find("Balloon").GetChild(dialogues[order].size - 1).gameObject;
                                StartCoroutine(PopUp(frontBubble));
                                StartCoroutine(TypeSentence(frontBubble, dialogues[order].dialogue));
                            }
                            if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return)) && typeDone)
                            {
                                order++;
                                firstPlay = true;
                                typeDone = false;
                            }
                        }
                        else
                        {
                            if (firstPlay)
                            {
                                firstPlay = false;

                                if (dialogues[order - 1].size == 9 || dialogues[order - 1].size == 10)
                                {
                                    backBubble = frontBubble.transform.GetChild(int.Parse(dialogues[order - 1].dialogue)).gameObject;
                                }
                                else
                                {
                                    backBubble = frontBubble;
                                }

                                frontBubble = GameObject.Find(dialogues[order].charName).transform.Find("Balloon").GetChild(dialogues[order].size - 1).gameObject;

                                if (backBubble != frontBubble && backBubble != null && dialogues[order - 1].dialogueName == dialogues[order].dialogueName)
                                {
                                    if (dialogues[order - 1].size == 9 || dialogues[order - 1].size == 10)
                                    {
                                        StartCoroutine(PopDown(backBubble, backBubble.transform.childCount));
                                        if (dialogues[order - 2].size != dialogues[order].size)
                                            StartCoroutine(PopDown(selectionBubble));
                                    }
                                    else if (dialogues[order].size == 9 || dialogues[order].size == 10)
                                    {
                                        selectionBubble = backBubble;
                                    }
                                    else
                                    {
                                        StartCoroutine(PopDown(backBubble));
                                    }
                                    StartCoroutine(PopUp(frontBubble));
                                }

                                if (dialogues[order].size == 9 || dialogues[order].size == 10)
                                {
                                    frontBubble.transform.GetChild(int.Parse(dialogues[order].dialogue)).gameObject.SetActive(true);
                                }
                                else
                                {
                                    StartCoroutine(TypeSentence(frontBubble, dialogues[order].dialogue));
                                }
                            }

                            if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return)) && typeDone)
                            {
                                order++;
                                firstPlay = true;
                                typeDone = false;
                            }
                        }
                    }
                    else
                    {
                        while (dialogues[order].dialogueName != dialogueName && order < dialogues.Length - 1)
                        {
                            order++;
                            firstPlay = true;
                            typeDone = false;
                        }

                        if (dialogues[order].dialogueName == dialogueName && order < dialogues.Length)
                        {
                            frontBubble = GameObject.Find(dialogues[order].charName).transform.Find("Balloon").GetChild(dialogues[order].size - 1).gameObject;
                            StartCoroutine(PopUp(frontBubble));
                        }
                        else
                        {
                            order++;
                        }
                    }
                }
                else if (order == dialogues.Length)
                {
                    if (frontBubble.transform.GetChild(0).childCount == 0)
                    {
                        StartCoroutine(PopDown(frontBubble));
                    }
                    else
                    {
                        for(int i = 0; i < frontBubble.transform.childCount; i++)
                            StartCoroutine(PopDown(frontBubble.transform.GetChild(i).gameObject, frontBubble.transform.childCount));
                        StartCoroutine(PopDown(backBubble));
                    }

                    isDone = true;
                }
            }
        }
    }

    IEnumerator PopUp(GameObject bubble)
    {
        bubble.SetActive(true);
        yield return new WaitForSeconds(0.2f);
    }

    IEnumerator PopDown(GameObject bubble)
    {
        bubble.GetComponent<Animator>().SetBool("close", true);
        yield return new WaitForSeconds(0.2f);
        bubble.SetActive(false);
    }

    IEnumerator PopDown(GameObject bubble, int num)
    {
        for (int i = 0; i < num; i++)
        {
            bubble.transform.GetChild(i).GetComponent<Animator>().SetBool("close", true);
        }
        yield return new WaitForSeconds(0f);
        bubble.SetActive(false);
    }

    IEnumerator TypeSentence(GameObject bubble, string sentence)
    {
        Text text = bubble.transform.GetChild(0).GetComponent<Text>();
        text.text = string.Empty;

        yield return new WaitForSeconds(0.2f);

        foreach (var letter in sentence)
        {
            text.text += letter;
            yield return new WaitForSeconds(0.015f);
        }

        typeDone = true;
    }
}
