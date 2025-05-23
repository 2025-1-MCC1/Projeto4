using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Importante para trocar de cena

public class InteractionTrigger : MonoBehaviour
{
    public GameObject uiPanel; // ReferÍncia ao painel de UI
    private bool playerInside = false;

    void Start()
    {
        uiPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiPanel.SetActive(true);
            playerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiPanel.SetActive(false);
            playerInside = false;
        }
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Carregando cena 'quest'...");
            SceneManager.LoadScene("quest"); // Aqui ele muda de cena
        }
    }
}
