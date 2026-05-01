using TMPro;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private TMP_Text hint;
    private void ShowHint(string hintText)
    {
        hint?.gameObject.SetActive(true);
        hint.text = hintText;
    }
    private void HideHint()
    {
        hint?.gameObject.SetActive(false);
    }
    public void Hit(RaycastHit[] hits)
    {
        IInteractivable interactivable = null;
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.TryGetComponent<IInteractivable>(out interactivable))
                break;
        }
        if(interactivable != null)
        {
            ShowHint(interactivable.DisplayHint);
        }
        else
        {
            HideHint();
        }
    }
}
