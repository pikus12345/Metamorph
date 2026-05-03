using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackController : AttackController
{
    [Header("Animaton Settings")]
    [SerializeField] BodiesHandler bodiesHandler;

    [Header("Input Actions")]
    [SerializeField] private InputActionAsset inputActions;

    InputAction attackAction;

    private void Awake()
    {
        attackAction = inputActions?.FindActionMap("Player").FindAction("Attack");
    }
    protected override void PlayAnimation()
    {
        bodiesHandler.SetTrigger("Attack");
    }

    private void OnEnable()
    {
        attackAction.performed += Attack;
    }
    private void OnDisable()
    {
        attackAction.performed -= Attack;
    }
    public void Attack(InputAction.CallbackContext c)
    {
        Attack();
    }
}
