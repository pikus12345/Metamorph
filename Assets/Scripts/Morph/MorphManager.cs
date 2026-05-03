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

    [SerializeField] MorphType currentMorph;
    [SerializeField] InputActionAsset inputActions;
    [SerializeField] Animator morphesAnimator;
    [SerializeField] byte rafRemain = 0;

    private MorphUI morphUI;
    private InputAction morphKnightAction;
    private InputAction morphLizardAction;
    private InputAction morphOrcAction;

    private bool isKnightOpened = false;
    private bool isLizardOpened = false;
    private bool isOrcOpened = false;

    private void Awake()
    {
        morphKnightAction = inputActions.FindActionMap("Player").FindAction("MorphKnight");
        morphLizardAction = inputActions.FindActionMap("Player").FindAction("MorphLizard");
        morphOrcAction = inputActions.FindActionMap("Player").FindAction("MorphOrc");
        morphUI = FindAnyObjectByType<MorphUI>();
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
    public MorphType CurrentMorph => currentMorph;
    public void OpenKnightMorph()
    {
        isKnightOpened = true;
        morphUI.OpenKnightMorph();
    }
    public void OpenLizardMorph()
    {
        isLizardOpened = true;
        morphUI.OpenLizardMorph();
    }
    public void OpenOrcMorph()
    {
        isOrcOpened = true;
        morphUI.OpenOgreMorph();
    }
    public void AddRafs(byte amount)
    {
        rafRemain++;
    }
    public byte RafRemain => rafRemain;
    internal void Morph(MorphType type)
    {
        if (rafRemain == 0 || currentMorph == type) return;
       
        switch (type)
        {
            case MorphType.Knight:
                {
                    if (!isKnightOpened) return;
                    Debug.Log("Knight selected");
                    morphesAnimator.SetTrigger("Knight");
                    bodiesHandler.SetBody(MorphType.Knight);
                    break;
                }
            case MorphType.Lizard:
                {
                    if (!isLizardOpened) return;
                    Debug.Log("Lizard selected");
                    morphesAnimator.SetTrigger("Lizard");
                    bodiesHandler.SetBody(MorphType.Lizard);
                    break;
                }
            case MorphType.Orc:
                {
                    if (!isOrcOpened) return;
                    Debug.Log("Orc selected");
                    morphesAnimator.SetTrigger("Ogre");
                    bodiesHandler.SetBody(MorphType.Orc);
                    break;
                }
        }
        currentMorph = type;
        rafRemain--;
    }

}
