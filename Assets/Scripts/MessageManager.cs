using TMPro;
using UnityEngine;

public class MessageManager : Singleton<MessageManager>
{
    [SerializeField] private GameObject messagePrefab;
    [SerializeField] private Transform messageLayout;
    public void ShowMessage(string message)
    {
        GameObject obj = Instantiate(messagePrefab, messageLayout);
        obj.GetComponentInChildren<TMP_Text>().text = message;
    }
}
