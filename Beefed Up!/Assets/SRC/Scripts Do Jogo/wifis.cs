using UnityEngine;
using UnityEngine.SceneManagement;

public class wifis : MonoBehaviour
{
    public static wifis instance;

    public int score = 0;
    public int maxScore = 13;

    void Awake()
    {
        // Garante que só exista um ScoreManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoint()
    {
        score++;
        Debug.Log("Wifis coletados: " + score);

        if (score >= maxScore)
        {
            Debug.Log("Todos os wifis coletados! Mudando de cena...");
            SceneManager.LoadScene("Beefed Up! Cena Final"); // Substitua pelo nome exato da cena
        }
    }
}
