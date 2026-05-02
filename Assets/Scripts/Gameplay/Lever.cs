using System;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour, IInteractivable
{
    [SerializeField] private string ActivateHint;
    [SerializeField] private string DeactivateHint;

    [SerializeField] private UnityEvent ActivateEvent;
    [SerializeField] private UnityEvent DeactivateEvent;

    [SerializeField] private Animator animator;
    [SerializeField] private bool isActivated;

    [SerializeField] private AudioSource interactAudio;
    public string DisplayHint => isActivated ? DeactivateHint : ActivateHint;
    public bool Interact()
    {
        if (isActivated)
            Deactivate();
        else
            Activate();
        interactAudio.Play();
        return true;
    }
    private void Activate()
    {
        ActivateEvent.Invoke();
        isActivated = true;
        animator?.SetBool("Activated", true);
    }
    private void Deactivate() 
    { 
        DeactivateEvent.Invoke();
        isActivated = false;
        animator?.SetBool("Activated", false);
    }
}