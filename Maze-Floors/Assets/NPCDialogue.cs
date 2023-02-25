using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class NPCDialogue : MonoBehaviour
{
    public GameObject npc_dialogue;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject nextButton;
    public float wordSpeed;
    public bool playerIsNear;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && playerIsNear) {
            if(npc_dialogue.activeInHierarchy) {
                EmptyText();
            } else {
                npc_dialogue.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if(dialogueText.text == dialogue[index]) {
            nextButton.SetActive(true);
        }
    }

    public void EmptyText() {
        dialogueText.text = "";
        index = 0;
        npc_dialogue.SetActive(false);
    }

    IEnumerator Typing() {
        foreach(char letter in dialogue[index].ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine() {
        nextButton.SetActive(false);

        if(index < dialogue.Length - 1) {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        } else {
            EmptyText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerIsNear = false;
            EmptyText();
        }
    }
}
