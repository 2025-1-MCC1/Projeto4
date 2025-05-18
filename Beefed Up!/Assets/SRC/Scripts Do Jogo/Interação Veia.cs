using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class InteraçãoVeia : MonoBehaviour, IInteractable
{
    public GameObject dialogueUI;
    public Text dialogueText;
    public float typingSpeed = 0.03f;

    [TextArea(3, 10)]
    public string fullParagraph =
        "Luca, parabéns! Você conseguiu coletar todas as moedas necessárias. " +
        "Agora você pode reconstruir a cidade usando as moedas coletadas. " +
        "Você foi genial! Aceita reconstruir a cidade?";

    private List<string> sentences = new List<string>();
    private int currentSentence = 0;
    private bool isTalking = false;
    private bool isTyping = false;

    [Header("Botão final")]
    public GameObject perguntaPanel; // Painel com pergunta + botão
    public Button confirmarBotao;    // Botão que muda de cena
    public string nomeDaProximaCena = "CenaReconstrucao";

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

        // Ativa o painel com a pergunta e botão
        if (perguntaPanel != null && confirmarBotao != null)
        {
            perguntaPanel.SetActive(true);
            confirmarBotao.onClick.RemoveAllListeners();
            confirmarBotao.onClick.AddListener(MudarCena);
        }
    }

    void MudarCena()
    {
        SceneManager.LoadScene("Beefed Up! City Scene");
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
