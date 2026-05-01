using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackController : AttackController
{
    [Header("Input Actions")]
    [SerializeField] private InputActionAsset inputActions;

    InputAction attackAction;

    private void Awake()
    {
        attackAction = inputActions?.FindActionMap("Player").FindAction("Attack");
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
