using UnityEngine;
using UnityEngine.UI;

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
        // Lógica de morte do personagem
        Debug.Log("Voce morreu!");
        // Destroy(gameObject); // se quiser destruir
    }

    // Testar o dano
    //void Update()
    //{
    // if (Input.GetKeyDown(KeyCode.Space))
    // {
    //     TakeDamage(10f); // Tira 10 de vida quando aperta espaço
    // }
    // }

}
