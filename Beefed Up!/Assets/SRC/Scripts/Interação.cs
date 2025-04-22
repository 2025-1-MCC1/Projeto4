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
        interactionInputAction.action.performed += Interact;
    }

    private void OnDisable()
    {
        interactionInputAction.action.performed -= Interact;
    }
    private void Interact(InputAction.CallbackContext obj)
    {
        Ray playerAim = new Ray(InteractionSource.position, InteractionSource.forward);
        if(Physics.Raycast(playerAim, out RaycastHit hitInfo, InteractionRange))
        {
            if (hitInfo.collider.TryGetComponent(out IInteractable interactableObj))
            {
                interactableObj.Interact();
            }
        }
    }
}
