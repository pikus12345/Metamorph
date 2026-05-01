using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackController : AttackController
{
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private int damage;

    [Header("Attack area settings")]
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask mask;

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
    public void Attack(InputAction.CallbackContext c) => Attack();
}
