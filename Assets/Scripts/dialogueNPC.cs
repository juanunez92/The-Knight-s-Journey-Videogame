using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class dialogueNPC : MonoBehaviour
{
    [SerializeField] private GameObject dialogueStart;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogue;

    [SerializeField,TextArea(4,6)] private string[] dialogueLines;

    private bool isPlayerInRange;
    private bool dialogueStarted;
    private int line;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Fire1"))
        {
            if (!dialogueStarted)
            {
                StartDialogue();
            }
            else if (dialogue.text == dialogueLines[line])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogue.text = dialogueLines[line];

            }
        }
    }


    private void NextLine() {

        line++;

        if (line < dialogueLines.Length)
        {
            StartCoroutine(OrderLines());
        }
        else
        {
            dialogueStarted = false;
            dialoguePanel.SetActive(false);
            dialogueStart.SetActive(true);
            Time.timeScale = 1f;
        }

    }



    private void StartDialogue() {


        dialogueStarted = true;
        dialoguePanel.SetActive(true);
        dialogueStart.SetActive(false);
        line = 0;
        Time.timeScale = 0f;
        StartCoroutine(OrderLines());
    }

    private IEnumerator OrderLines() {


        dialogue.text = string.Empty;

        foreach (char ch in dialogueLines[line]) {

            dialogue.text += ch;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            isPlayerInRange = true;
            dialogueStart.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            isPlayerInRange = false;
            dialogueStart.SetActive(false);

        }
    }
}
