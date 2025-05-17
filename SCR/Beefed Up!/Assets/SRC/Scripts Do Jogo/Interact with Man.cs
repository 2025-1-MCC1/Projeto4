using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InteractwithMan : MonoBehaviour, IInteractable
{
    public GameObject dialogueUI;
    public Text dialogueText;
    public float typingSpeed = 0.03f;

    [TextArea(3, 10)]
    public string fullParagraph =
        "Luca, após seu pai, o governador Luis, cortar os salários dos cientistas, Victor, um deles, criou bois mutantes em segredo e os soltou na cidade. " +
        "Eles se tornaram agressivos, atacaram pessoas e causaram grande destruição. " +
        "Seu pai morreu no ataque, e agora cabe a você reconstruir a cidade. Vá até o feixe de luz vermelho para sua primeira missão!";

    private List<string> sentences = new List<string>();
    private int currentSentence = 0;
    private bool isTalking = false;
    private bool isTyping = false;

    public void Interact()
    {
        if (!isTalking)
        {
            SplitParagraph();
            currentSentence = 0;
            dialogueUI.SetActive(true);
            isTalking = true;
            StartCoroutine(TypeSentence(sentences[currentSentence]));
        }
    }

    void Update()
    {
        if (isTalking && Input.GetKeyDown(KeyCode.Return))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = sentences[currentSentence];
                isTyping = false;
            }
            else
            {
                currentSentence++;
                if (currentSentence < sentences.Count)
                {
                    StartCoroutine(TypeSentence(sentences[currentSentence]));
                }
                else
                {
                    EndDialogue();
                }
            }
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void EndDialogue()
    {
        dialogueUI.SetActive(false);
        isTalking = false;
    }

    void SplitParagraph()
    {
        sentences.Clear();

        string[] parts = fullParagraph.Split('.');
        foreach (string part in parts)
        {
            string trimmed = part.Trim();
            if (!string.IsNullOrEmpty(trimmed))
            {
                sentences.Add(trimmed + ".");
            }
        }
    }
}
