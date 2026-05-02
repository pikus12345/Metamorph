using UnityEngine;

public class Door : MonoBehaviour, IInteractivable
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

    public string DisplayHint => isOpened ? "" : Hint;
    public bool Interact()
    {
        if (isActivatingByLever)
        {
            Debug.Log("This door is opening only by a lever");
            return false;
        }
        else
        {
            Open();
            return true;
        }
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
}
