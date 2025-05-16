using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class InteraçãoVeia3 : MonoBehaviour, IInteractable
{
    public GameObject dialogueUI;
    public Text dialogueText;
    public float typingSpeed = 0.03f;

    [TextArea(3, 10)]
    public string fullParagraph =
        " LUCA, UAU! SEM PALAVRAS PRA VOCÊ GAROTO. " +
        " A cidade agora está melhor do que nunca. " +
        " Graças a você nossa vida agora pode voltar ao normal. " +
        " Obrigada, Luca!.";

    private List<string> sentences = new List<string>();
    private int currentSentence = 0;
    private bool isTalking = false;
    private bool isTyping = false;
    private bool readyToChangeScene = false; // Flag nova

    public string sceneToLoad = "Beefed Up! Cena Final"; // Substitua pelo nome exato da cena

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
            else if (readyToChangeScene)
            {
                // Trocar de cena após diálogo completo + ENTER
                SceneManager.LoadScene("Fim do Jogo");
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
        // Não fecha o UI ainda — espera o próximo ENTER para mudar de cena
        readyToChangeScene = true;
        dialogueText.text = "[Pressione ENTER para continuar]";
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
