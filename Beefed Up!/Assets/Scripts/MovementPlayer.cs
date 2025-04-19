using UnityEngine;
using UnityEngine.Rendering;

public class MovementPlayer : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Vector3 direção;

    private float Velocidade = 5f;

    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direção.Set(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        character.Move(direção * Time.deltaTime * Velocidade);
        character.Move(Vector3.down * Time.deltaTime);

        if(direção != Vector3.zero)
        {
            animator.SetBool("Andando", true);
            transform.forward = Vector3.Slerp(transform.forward, direção, Time.deltaTime * 10);
        }
        else
        {
            animator.SetBool("Andando", false);
        }
    }
}
