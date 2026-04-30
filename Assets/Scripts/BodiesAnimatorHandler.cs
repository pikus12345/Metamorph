using UnityEngine;

public class BodiesAnimatorHandler : MonoBehaviour
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
}
