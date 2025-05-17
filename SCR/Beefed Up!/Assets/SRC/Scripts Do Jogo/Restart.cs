using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Este método será chamado quando o jogador clicar em "Restart"
    public void PlayGame()
    {
        // Carrega a cena do jogo (certifique-se de adicionar a cena nas configurações de build!)
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
