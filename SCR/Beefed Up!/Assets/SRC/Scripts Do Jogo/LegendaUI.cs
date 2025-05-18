using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LegendaUI : MonoBehaviour
{
    public GameObject painelLegenda;   // <-- Objeto LegendaUI
    public Text legendaTexto;
    public float tempoExibicao = 5f;

    void Start()
    {
        painelLegenda.SetActive(false);
        StartCoroutine(MostrarLegenda("Procure o homem de azul!"));
    }

    IEnumerator MostrarLegenda(string mensagem)
    {
        legendaTexto.text = mensagem;
        painelLegenda.SetActive(true);
        yield return new WaitForSeconds(tempoExibicao);
        painelLegenda.SetActive(false);
    }
}
