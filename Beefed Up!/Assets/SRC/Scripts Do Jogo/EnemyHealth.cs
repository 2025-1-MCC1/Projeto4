using UnityEngine;

public class Monstro : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima; // Inicializa a vida
    }

    // M�todo para o monstro levar dano
    public void LevarDano(int dano)
    {
        vidaAtual -= dano;
        Debug.Log("Monstro levou " + dano + " de dano. Vida atual: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log("Monstro morreu!");
        // Aqui voc� pode adicionar anima��o, desativar o inimigo, destruir o objeto, etc.
        Destroy(gameObject);
    }
}
