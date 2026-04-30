using UnityEngine;
using UnityEngine.InputSystem;

public class MorphManager : MonoBehaviour
{
    [SerializeField] BodiesAnimatorHandler bodiesAnimatorHandler;

    [SerializeField] InputActionAsset inputActions;
    private InputAction morphKnightAction;
    private InputAction morphLizardAction;
    private InputAction morphOrcAction;

    public enum MorphType
    {
        Knight,
        Lizard,
        Orc
    }

    private void Awake()
    {
        morphKnightAction = inputActions.FindActionMap("Player").FindAction("MorphKnight");
        morphLizardAction = inputActions.FindActionMap("Player").FindAction("MorphLizard");
        morphOrcAction = inputActions.FindActionMap("Player").FindAction("MorphOrc");
    }
    private void OnEnable()
    {
        morphKnightAction.performed += MorphKnight;
        morphKnightAction.Enable();
        morphLizardAction.performed += MorphLizard;
        morphLizardAction.Enable();
        morphOrcAction.performed -= MorphOrc;
        morphOrcAction.Enable();
    }
    private void MorphKnight(InputAction.CallbackContext context) => Morph(MorphType.Knight);
    private void MorphLizard(InputAction.CallbackContext context) => Morph(MorphType.Lizard);
    private void MorphOrc(InputAction.CallbackContext context) => Morph(MorphType.Orc);

    internal void Morph(MorphType type)
    {
        switch (type)
        {
            case MorphType.Knight:
                {
                    Debug.Log("Knight");
                    break;
                }
            case MorphType.Lizard:
                {
                    Debug.Log("Lizard");
                    break;
                }
            case MorphType.Orc:
                {
                    Debug.Log("Orc");
                    break;
                }
        }
    }
}
