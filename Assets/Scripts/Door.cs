using UnityEngine;

public class Door : MonoBehaviour, IInteractivable
{
    [SerializeField] private bool isActivatingByLever;
    [SerializeField] private string Hint;

    public string DisplayHint => Hint;
    public void Interact()
    {
        if (isActivatingByLever)
        {
            Debug.Log("This door is opening only by a lever");
        }
        else
        {
            Open();
        }
    }
    public void Open()
    {

    }
}
