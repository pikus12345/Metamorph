using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillObjective : MonoBehaviour
{
    [SerializeField] private List<HealthController> remainObjectives = new List<HealthController>();

    [SerializeField] private UnityEvent OnCompleted;

    private void OnEnable()
    {
        foreach (var objective in remainObjectives)
        {
            objective.OnDie += () => RemoveObjective(objective);
        }
    }
    private void RemoveObjective(HealthController damageable)
    {
        remainObjectives.Remove(damageable);
        if (remainObjectives.Count == 0) ObjectiveCompleted();
    }
    private void OnDisable()
    {
        foreach (var objective in remainObjectives)
        {
            objective.OnDie -= () => RemoveObjective(objective);
        }
    }
    private void ObjectiveCompleted()
    {
        OnCompleted?.Invoke();
        Destroy(gameObject);
    }
}
