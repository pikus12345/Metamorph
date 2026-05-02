using UnityEngine;
using UnityEngine.InputSystem;

public enum MorphType
{
    Knight,
    Lizard,
    Orc
}
public class MorphManager : MonoBehaviour
{
    [SerializeField] BodiesHandler bodiesHandler;

    [SerializeField] InputActionAsset inputActions;
    [SerializeField] Animator morphesAnimator;
    private InputAction morphKnightAction;
    private InputAction morphLizardAction;
    private InputAction morphOrcAction;
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
        morphOrcAction.performed += MorphOrc;
        morphOrcAction.Enable();
    }
    private void OnDisable()
    {
        morphKnightAction.performed -= MorphKnight;
        morphKnightAction.Disable();
        morphLizardAction.performed -= MorphLizard;
        morphLizardAction.Disable();
        morphOrcAction.performed -= MorphOrc;
        morphOrcAction.Disable();
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
                    Debug.Log("Knight selected");
                    morphesAnimator.SetTrigger("Knight");
                    bodiesHandler.SetBody(MorphType.Knight);
                    break;
                }
            case MorphType.Lizard:
                {
                    Debug.Log("Lizard selected");
                    morphesAnimator.SetTrigger("Lizard");
                    bodiesHandler.SetBody(MorphType.Lizard);
                    break;
                }
            case MorphType.Orc:
                {
                    Debug.Log("Orc selected");
                    morphesAnimator.SetTrigger("Ogre");
                    bodiesHandler.SetBody(MorphType.Orc);
                    break;
                }
        }
    }
}
