using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Este m�todo ser� chamado quando o jogador clicar em "Restart"
    public void PlayGame()
    {
        // Carrega a cena do jogo (certifique-se de adicionar a cena nas configura��es de build!)
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
