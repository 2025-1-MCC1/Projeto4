using UnityEngine;
using UnityEngine.Rendering;

public class MovementPlayer : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Vector3 dire��o;

    private float Velocidade = 5f;

    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dire��o.Set(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        character.Move(dire��o * Time.deltaTime * Velocidade);
        character.Move(Vector3.down * Time.deltaTime);

        if(dire��o != Vector3.zero)
        {
            animator.SetBool("Andando", true);
            transform.forward = Vector3.Slerp(transform.forward, dire��o, Time.deltaTime * 10);
        }
        else
        {
            animator.SetBool("Andando", false);
        }
    }
}
