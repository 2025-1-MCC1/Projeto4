using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Você morreu!");
        // Pausa o jogo (opcional, mas geralmente quando troca de cena não precisa)
        Time.timeScale = 1f;

        // Carrega a cena de Game Over
        SceneManager.LoadScene("GameOver");

        // Destruir o jogador (opcional)
        Destroy(gameObject);
    }


    // Testar o dano
    //void Update()
    //{
    //if (Input.GetKeyDown(KeyCode.Space))
    //{
    //TakeDamage(10f); // Tira 10 de vida quando aperta espaço
    //}
    //}

}
