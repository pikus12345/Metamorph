using UnityEngine;

public class InteractionAreaHandler : MonoBehaviour
{
    [SerializeField] private InteractionManager interactionManager;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float areaRadius = 2f;
    private void Update()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, areaRadius, transform.forward, distance);
        interactionManager.Hit(hits);
    }
    private void OnDrawGizmos()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward * distance, out hit))
            if(hit.distance < distance)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawWireSphere(hit.point, areaRadius);
            }
    }
}
