using UnityEngine.InputSystem;
using UnityEngine;



interface IInteractable
{
    public void Interact();
}
public class Interação : MonoBehaviour
{
    public Transform InteractionSource; // Fonte de interação

    public float InteractionRange; // Alcance da interação

    public InputActionReference interactionInputAction;

    private void OnEnable()
    {
        //interactionInputAction.action.performed += Interact;
    }

    private void OnDisable()
    {
        //interactionInputAction.action.performed -= Interact;
    }
    //private void Interact(InputAction.CallbackContext obj)
    //{
    //    //Vector3 interactionPosition = InteractionSource.position + Vector3.up;
    //    InteractionSource.position += new Vector3(0, 1f, 0);
    //    Ray playerAim = new Ray(InteractionSource.position, InteractionSource.forward);
    //
    //    // Desenha o raio na aba Scene para visualização
    //    Debug.DrawRay(playerAim.origin, playerAim.direction * InteractionRange, Color.red, 1f);
    //
    //    Debug.Log("lançando raio");
    //
    //    if (Physics.Raycast(playerAim, out RaycastHit hitInfo, InteractionRange))
    //    {
    //        
    //        if (hitInfo.collider.TryGetComponent(out IInteractable interactableObj))
    //        {
    //            interactableObj.Interact();
    //        }
    //    }
    //}

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 interactionPosition = InteractionSource.position + Vector3.up * 2.5f; // mirar o npc com o player (escolher player no inspector e alterar p range do raio)
            //Vector3 interactionPosition = InteractionSource.position; // mirar o npc com a FreeLookCam (escolher player no inspector e alterar p range do raio)
            //InteractionSource.position += new Vector3(0, 1f, 0);
            Ray playerAim = new Ray(interactionPosition, InteractionSource.forward);

            // Desenha o raio na aba Scene para visualização
            Debug.DrawRay(playerAim.origin, playerAim.direction * InteractionRange, Color.red, 1f);

            //Debug.Log("lançando raio");

            if (Physics.Raycast(playerAim, out RaycastHit hitInfo, InteractionRange))
            {

                if (hitInfo.collider.TryGetComponent(out IInteractable interactableObj))
                {
                    interactableObj.Interact();
                }
            }
        }
    }
}
