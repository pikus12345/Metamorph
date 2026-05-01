using UnityEngine;
using UnityEngine.InputSystem;

public class AttackController : MonoBehaviour
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
    public void Attack(InputAction.CallbackContext c)
    {
        Vector3 areaPos = transform.position + transform.forward * attackDistance;
        Collider[] hits = Physics.OverlapSphere(areaPos, attackRadius, mask, QueryTriggerInteraction.Ignore);
        foreach (Collider hit in hits)
        {
            IDamageable damageable = null;
            if (hit.TryGetComponent(out damageable))
            {
                damageable.Hurt(damage);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 areaPos = transform.position + transform.forward * attackDistance;
        Gizmos.DrawSphere(areaPos, attackRadius);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(areaPos, attackRadius);
    }
}
