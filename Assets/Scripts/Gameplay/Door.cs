using UnityEngine;

public class Door : MonoBehaviour, IInteractivable
{
    [SerializeField] private bool isActivatingByLever;
    [SerializeField] private string Hint;
    [SerializeField] private Animator animator;

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
        Debug.Log("Дверь открывается");
        isOpened = true;
        animator?.SetBool("Opened", isOpened);
    }
    public void Close() 
    {
        Debug.Log("Дверь закрывается");
        isOpened = false;
        animator?.SetBool("Opened", isOpened);
    }
}
