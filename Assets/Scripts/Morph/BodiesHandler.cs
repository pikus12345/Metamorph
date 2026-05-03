using UnityEngine;

public class BodiesHandler : MonoBehaviour
{
    [SerializeField] private Animator knightAnimator;
    [SerializeField] private Animator lizardAnimator;
    [SerializeField] private Animator orcAnimator;

    internal void SetBool(int id, bool value)
    {
        knightAnimator?.SetBool(id, value);
        lizardAnimator?.SetBool(id, value);
        orcAnimator?.SetBool(id, value);
    }
    internal void SetFloat(int id, float value)
    {
        knightAnimator?.SetFloat(id, value);
        lizardAnimator?.SetFloat(id, value);
        orcAnimator?.SetFloat(id, value);
    }
    internal void SetTrigger(string id)
    {
        knightAnimator?.SetTrigger(id);
        lizardAnimator?.SetTrigger(id);
        orcAnimator?.SetTrigger(id);
    }
    internal void SetBody(MorphType type)
    {
        switch (type)
        {
            case MorphType.Knight:
                {
                    knightAnimator.gameObject.SetActive(true);
                    lizardAnimator.gameObject.SetActive(false);
                    orcAnimator.gameObject.SetActive(false);
                    break;
                }
            case MorphType.Lizard:
                {
                    knightAnimator.gameObject.SetActive(false);
                    lizardAnimator.gameObject.SetActive(true);
                    orcAnimator.gameObject.SetActive(false);
                    break;
                }
            case MorphType.Orc:
                {
                    knightAnimator.gameObject.SetActive(false);
                    lizardAnimator.gameObject.SetActive(false);
                    orcAnimator.gameObject.SetActive(true);
                    break;
                }
        }
    }
}
