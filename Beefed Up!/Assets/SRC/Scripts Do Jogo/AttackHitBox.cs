using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{
    public int danoAtaque = 50;

    // Este objeto deve ter Collider com "Is Trigger" ativado
    private void OnTriggerEnter(Collider other)
    {
        Monstro monstro = other.GetComponent<Monstro>();
        if (monstro != null)
        {
            monstro.LevarDano(danoAtaque);
        }
    }
}
