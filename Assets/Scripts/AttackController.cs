using UnityEngine.InputSystem;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private int damage;

    [Header("Attack area settings")]
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask mask;
    public void Attack()
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
