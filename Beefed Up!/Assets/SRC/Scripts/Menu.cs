using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Este m�todo ser� chamado quando o jogador clicar em "Jogar"
    public void PlayGame()
    {
        // Carrega a cena do jogo (certifique-se de adicionar a cena nas configura��es de build!)
        SceneManager.LoadScene("Beefed Up! City Scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
