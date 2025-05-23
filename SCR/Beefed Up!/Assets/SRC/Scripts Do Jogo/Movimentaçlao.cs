    using UnityEngine;


public class Movimento : MonoBehaviour
{
    private CharacterController controller;
    private Transform myCamera;
    private Animator animator; // Colocar animação no personagem

    private bool estaNoChao;
    [SerializeField] private Transform peDoPersonagem;
    [SerializeField] private LayerMask colisaoLayer;

    private float ForcaY;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        myCamera = Camera.main.transform;
        animator = GetComponent<Animator>();
    }


    void Update()
    {            // Movimentação
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(horizontal, 0, vertical);

        movimento = myCamera.TransformDirection(movimento);
        movimento.y = 0;

        controller.Move(movimento * Time.deltaTime * 15);



        if (movimento != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimento), Time.deltaTime * 10);
        }

        animator.SetBool("Mover", movimento != Vector3.zero); // animação de correr
                                                              //Código paras fazer o personagem pular
        estaNoChao = Physics.CheckSphere(peDoPersonagem.position, 0.3f, colisaoLayer);
        animator.SetBool("EstarNoChao", estaNoChao);

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            ForcaY = 7f;  // Esse valor vai fazer o personagem ter uma impulsão pra cima
            animator.SetTrigger("Saltar");
        }

        if (ForcaY > -9.81f)
        {
            ForcaY += -9.81f * Time.deltaTime;  // O valor negativo vai fazer o personagem voltar para baixo
        }

        controller.Move(new Vector3(0, ForcaY, 0) * Time.deltaTime);
    }
}
