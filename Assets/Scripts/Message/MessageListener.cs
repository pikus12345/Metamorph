using UnityEngine;

public class MessageListener : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MessageTrigger msgTrigger;
        if (other.TryGetComponent(out msgTrigger)) 
        {
            MessageManager.Instance.ShowMessage(msgTrigger.GetMessage());
        }
    }
}
