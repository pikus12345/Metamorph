using UnityEngine;

public class Door : MonoBehaviour, IInteractivable
{
    [SerializeField] private bool isActivatingByLever;
    public void Activate()
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
