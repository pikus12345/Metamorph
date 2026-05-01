using UnityEngine;

public class InteractionAreaHandler : MonoBehaviour
{
    [SerializeField] private InteractionManager interactionManager;
    private void OnTriggerEnter(Collider other)
    {
        interactionManager.TriggerEnter(other);
    }
    private void OnTriggerStay(Collider other)
    {
        interactionManager.TriggerStay(other);
    }
    private void OnTriggerExit(Collider other)
    {
        interactionManager.TriggerExit(other);
    }
}
