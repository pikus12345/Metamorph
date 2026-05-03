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

    [SerializeField] private float respawnWaiting;
    [SerializeField] private GameObject rafModel;

    private void Awake()
    {
        morphManager = FindAnyObjectByType<MorphManager>();
    }
    public bool Interact()
    {
        if (!enabledPickup) return false;
        morphManager.AddRafs(1);
        morphManager.gameObject.GetComponent<HealthController>().Heal(100);

        if (OpenKnight) morphManager.OpenKnightMorph();
        if (OpenLizard) morphManager.OpenLizardMorph();
        if (OpenOgre) morphManager.OpenOrcMorph();

        enabledPickup = false;
        rafModel.SetActive(false);
        StartCoroutine(WaitingForRespawn());

        return true;
    }
    private void Respawn()
    {
        rafModel.SetActive(true);
        enabledPickup = true;
    }
    IEnumerator WaitingForRespawn()
    {
        yield return new WaitUntil(() => morphManager.RafRemain == 0);
        yield return new WaitForSeconds(respawnWaiting);
        Respawn();
    }
}
