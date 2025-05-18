using UnityEngine;

public class NPCAtacando : MonoBehaviour
{
    public Transform jogador;
    public float distanciaAtaque = 2.5f;
    public float tempoEntreAtaques = 2f;

    private Animator anim;
    private float cronometroAtaque = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (jogador == null)
        {
            Debug.LogError("Jogador não atribuído no Inspector!");
        }
    }

    void Update()
    {
        if (jogador == null) return;

        float distancia = Vector3.Distance(transform.position, jogador.position);
        Debug.Log("Distância até o jogador: " + distancia);

        if (distancia <= distanciaAtaque)
        {
            cronometroAtaque += Time.deltaTime;
            Debug.Log("NPC está no alcance. Tempo acumulado: " + cronometroAtaque);

            if (cronometroAtaque >= tempoEntreAtaques)
            {
                Debug.Log("NPC vai atacar!");
                anim.SetTrigger("Attack");
                cronometroAtaque = 0f;
            }
        }
    }
}
