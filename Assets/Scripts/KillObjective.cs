using System.Collections.Generic;
using UnityEngine;

public class KillObjective : MonoBehaviour
{
    [SerializeField] IDamageable[] objectives;
    private List<IDamageable> remainObjectives;


    private void OnEnable()
    {
        foreach (var objective in remainObjectives) 
        {
            objective.OnDie += () => RemoveObjective(objective);
        }
    }
    private void RemoveObjective(IDamageable damageable)
    {
        remainObjectives.Remove(damageable);
    }
    private void OnDisable()
    {
        foreach (var objective in remainObjectives)
        {
            objective.OnDie -= () => RemoveObjective(objective);
        }
    }
}
