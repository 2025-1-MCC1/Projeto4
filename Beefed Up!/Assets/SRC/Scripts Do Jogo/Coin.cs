using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    public static Coin instance;

    public int totalCoins = 0;
    public Text coinText;
    public int coinValue = 200;
    public string nomeDaProximaCena = "ProximaFase"; // Defina o nome da próxima cena
    public int limiteParaTrocarCena = 5000;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        UpdateCoinUI();
    }

    public void AddCoins()
    {
        totalCoins += coinValue;
        UpdateCoinUI();

        if (totalCoins >= limiteParaTrocarCena)
        {
            TrocarDeCena();
        }
    }

    void UpdateCoinUI()
    {
        coinText.text = "moedas: " + totalCoins;
    }

    public void CollectCoin(GameObject coin)
    {
        AddCoins();
        Destroy(coin);
    }

    void TrocarDeCena()
    {
        SceneManager.LoadScene("Cena pós quest 1");
    }
}
