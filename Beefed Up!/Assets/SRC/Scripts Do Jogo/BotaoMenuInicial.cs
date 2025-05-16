using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoMenuInicial : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu"); // Substitua por exatamente o nome da sua cena
    }
}
