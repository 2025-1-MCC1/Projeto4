using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject attackHitbox;
    public float attackDuration = 0.3f;
    public float attackCooldown = 0.5f;

    private bool canAttack = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            StartCoroutine(DoAttack());
        }
    }

    private System.Collections.IEnumerator DoAttack()
    {
        canAttack = false;

        // Ativa a hitbox por alguns segundos
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackHitbox.SetActive(false);

        // Espera cooldown antes de permitir novo ataque
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
