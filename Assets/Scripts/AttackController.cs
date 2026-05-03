using UnityEngine.InputSystem;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [Header("Damage settings")]
    [SerializeField] private int damage;

    [Header("Attack area settings")]
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask mask;

    [SerializeField] private Animator animator;
    public void Attack()
    {
        PlayAnimation();
    }
    public void DoDamage()
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
    protected virtual void PlayAnimation()
    {
        animator?.SetTrigger("Attack");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 areaPos = transform.position + transform.forward * attackDistance;
        Gizmos.DrawSphere(areaPos, attackRadius);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(areaPos, attackRadius);
    }
}
