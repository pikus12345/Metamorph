using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private TMP_Text hint;
    [SerializeField] private InputActionAsset inputActions;
    private IInteractivable interactivable = null;
    private InputAction interactAction;

    private void Awake()
    {
        interactAction = inputActions?.FindActionMap("Player").FindAction("Interact");
    }
    private void OnEnable()
    {
        interactAction.performed += TryInteract;
    }
    private void OnDisable()
    {
        interactAction.performed -= TryInteract;
    }
    private void TryInteract(InputAction.CallbackContext c)
    {
        interactivable?.Interact();
    }
    private void ShowHint(string hintText)
    {
        hint?.gameObject.SetActive(true);
        hint.text = hintText;
    }
    private void HideHint()
    {
        hint?.gameObject.SetActive(false);
    }
    public void Hit(RaycastHit[] hits)
    {
        interactivable = null;
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.TryGetComponent<IInteractivable>(out interactivable))
                break;
        }
        if(interactivable != null)
        {
            ShowHint(interactivable.DisplayHint);
        }
        else
        {
            HideHint();
        }
    }
}
