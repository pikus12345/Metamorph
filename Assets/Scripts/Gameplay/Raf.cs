using System.Collections;
using UnityEngine;

public class Raf : MonoBehaviour, IInteractivable
{
    [SerializeField] private string Hint;
    private MorphManager morphManager;
    public string DisplayHint => enabledPickup ? Hint : "";
    [SerializeField] private bool OpenKnight;
    [SerializeField] private bool OpenLizard;
    [SerializeField] private bool OpenOgre;

    [SerializeField] private bool enabledPickup;

    private void Awake()
    {
        morphManager = FindAnyObjectByType<MorphManager>();
    }
    public bool Interact()
    {
        morphManager.AddRafs(1);

        if (OpenKnight) morphManager.OpenKnightMorph();
        if (OpenLizard) morphManager.OpenLizardMorph();
        if (OpenOgre) morphManager.OpenOrcMorph();

        enabled = false;

        return true;
    }
    IEnumerator WaitingForRespawn()
    {
        
    }
}
