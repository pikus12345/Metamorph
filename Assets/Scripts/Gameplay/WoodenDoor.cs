using System;
using UnityEngine;

public class WoodenDoor : MonoBehaviour, IInteractivable, IDamageable
{
    [Header("Door Settings")]
    [SerializeField] private bool isActivatingByLever;
    [SerializeField] private string Hint;

    [Header("Animation Settings")]
    [SerializeField] private Animator animator;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource DoorCloseSrc;
    [SerializeField] private AudioSource DoorOpenSrc;

    private bool isOpened = false;

    public event Action OnDie;

    public string DisplayHint => isOpened ? "" : Hint;
    public bool Interact()
    {
        Debug.Log("This door is opening only by a lever");
        return false;
    }
    public void Open()
    {
        isOpened = true;
        animator?.SetBool("Opened", isOpened);
        DoorOpenSrc.Play();
    }
    public void Close() 
    {
        isOpened = false;
        animator?.SetBool("Opened", isOpened);
        DoorCloseSrc.Play();
    }

    public void Hurt(int amount)
    {
        if(amount >= 3) Open();
    }
}
