using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using System;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    private class Dialouge
    {
        public string name;
        [TextArea] public string dialouge;
    }

    public event Action OnDialogueComplete;

    [SerializeField] private Dialouge[] dialogues;

    [Space(10)]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject arrowObj;
    [SerializeField] private float typeDelay = 0.1f;
    [SerializeField] private float nextDialogueTime = 2;
    [SerializeField] private bool isGetInput;

    private readonly StringBuilder stringBuilder = new();
    private WaitForSeconds waitForSeconds;
    private int currentDialogueIndex;
    private string currentDialogue;
    private bool isPriting;
    private bool isCompleted;

    private void Start()
    {
        isPriting = false;
        isCompleted = false;
        arrowObj.SetActive(false);
        currentDialogueIndex = 0;
        waitForSeconds = new WaitForSeconds(typeDelay);

        if (isGetInput) PrintDialogueWithInput();
        else PrintDialogueWithoutInput();
    }

    public void NextDialogue()
    {
        if (!isGetInput) return;
        if (isPriting) return;
        if (currentDialogueIndex >= dialogues.Length - 1)
        {
            // fire complete event
            if (!isCompleted)
            {
                isCompleted = true;
                OnDialogueComplete?.Invoke();
                gameObject.SetActive(false);
            }
            return;
        }

        currentDialogueIndex = currentDialogueIndex + 1 > dialogues.Length - 1 ? dialogues.Length - 1: currentDialogueIndex + 1;
        PrintDialogueWithInput();
    }

    private void PrintDialogueWithInput()
    {
        if (isPriting) return;
        if (dialogues.Length == 0) return;

        // initialize
        isPriting = true;
        stringBuilder.Clear();
        arrowObj.SetActive(false);
        currentDialogue = dialogues[currentDialogueIndex].dialouge;

        // update UI
        nameText.text = dialogues[currentDialogueIndex].name;
        StartCoroutine(C_PrintDialogue());
    }

    private void PrintDialogueWithoutInput()
    {
        if (dialogues.Length == 0) return;

        // initialize
        stringBuilder.Clear();
        arrowObj.SetActive(false);
        StartCoroutine(C_PrintDialogueWithoutInput());
    }

    private IEnumerator C_PrintDialogueWithoutInput()
    {
        for (int i = 0; i < dialogues.Length; i++)
        {
            isPriting = true;
            stringBuilder.Clear();
            currentDialogue = dialogues[i].dialouge;
            nameText.text = dialogues[i].name;
            StartCoroutine(C_PrintDialogue());

            yield return new WaitUntil(() => !isPriting);
            yield return new WaitForSeconds(nextDialogueTime);
        }

        gameObject.SetActive(false);
    }

    private IEnumerator C_PrintDialogue()
    {
        // print dialogue letter one by one
        for (int i = 0; i < currentDialogue.Length; i++)
        {
            stringBuilder.Append(currentDialogue[i]);
            dialogueText.text = stringBuilder.ToString();
            yield return waitForSeconds;
        }

        isPriting = false;
        if (isGetInput) arrowObj.SetActive(true);
    }
}
