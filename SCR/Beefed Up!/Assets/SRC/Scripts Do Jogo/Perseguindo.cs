using UnityEngine;
using UnityEngine.AI;

public class Perseguindo : MonoBehaviour
{
    public Transform jogador;
    public float distanciaParaParar = 2.5f;

    private NavMeshAgent agente;
    private Animator anim;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        if (jogador == null)
        {
            GameObject go = GameObject.FindWithTag("Player");
            if (go != null) jogador = go.transform;
        }
    }

    void Update()
    {
        if (jogador == null) return;

        float distancia = Vector3.Distance(transform.position, jogador.position);

        if (distancia > distanciaParaParar)
        {
            agente.isStopped = false;
            agente.SetDestination(jogador.position);
            anim.SetBool("Andando", true); // animação de andar
        }
        else
        {
            agente.isStopped = true;
            anim.SetBool("Andando", false);
            anim.SetTrigger("Attack"); // ataca quando perto
        }
    }
}
