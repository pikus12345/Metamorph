using System.Collections.Generic;
using UnityEngine;

public class KillObjective : MonoBehaviour
{
    [SerializeField] IDamageable[] objectives;
    private List<IDamageable> remainObjectives;


    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
}
