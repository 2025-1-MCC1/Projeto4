using UnityEngine;

public class DarDano : MonoBehaviour
{
    public int dano = 10;

    public void CausarDano()
    {
        // Aqui você pode detectar o jogador e aplicar dano
        Collider[] atingidos = Physics.OverlapSphere(transform.position + transform.forward, 2f);
        foreach (var col in atingidos)
        {
            if (col.CompareTag("Player"))
            {
                Debug.Log("Jogador atingido!");
                col.GetComponent<Health>()?.TakeDamage(dano);
            }
        }
    }
}
