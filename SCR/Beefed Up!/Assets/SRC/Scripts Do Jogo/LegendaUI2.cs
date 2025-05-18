using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LegendaUI2 : MonoBehaviour
{
    public GameObject painelLegenda;   // <-- Objeto LegendaUI
    public Text legendaTexto;
    public float tempoExibicao = 5f;

    void Start()
    {
        painelLegenda.SetActive(false);
        StartCoroutine(MostrarLegenda("Fale com a idosa na sua frente"));
    }

    IEnumerator MostrarLegenda(string mensagem)
    {
        legendaTexto.text = mensagem;
        painelLegenda.SetActive(true);
        yield return new WaitForSeconds(tempoExibicao);
        painelLegenda.SetActive(false);
    }
}
