using UnityEngine;

public class MessageTrigger : MonoBehaviour
{
    [SerializeField] string Message;
    public string GetMessage()
    {
        Destroy(gameObject);
        return Message;
    }
}