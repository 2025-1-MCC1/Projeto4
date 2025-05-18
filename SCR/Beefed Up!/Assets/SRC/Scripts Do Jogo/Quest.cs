using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quest : MonoBehaviour
{
    public GameObject painelLegenda;   // <-- Objeto LegendaUI
    public Text legendaTexto;
    public float tempoExibicao = 5f;

    void Start()
    {
        painelLegenda.SetActive(false);
        StartCoroutine(MostrarLegenda("Derrote todos os monstros e pegue todas as moedas, para reconstruir a cidade  (clique com o botão esquerdo na barriga do monstro para atacar"));
    }

    IEnumerator MostrarLegenda(string mensagem)
    {
        legendaTexto.text = mensagem;
        painelLegenda.SetActive(true);
        yield return new WaitForSeconds(tempoExibicao);
        painelLegenda.SetActive(false);
    }
}
