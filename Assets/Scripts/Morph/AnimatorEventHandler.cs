using StarterAssets;
using UnityEngine;

public class AnimatorEventHandler : MonoBehaviour
{
    [SerializeField] private ThirdPersonController _controller;
    public void OnFootstep(AnimationEvent e)
    {
        _controller.OnFootstep(e);
    }
}
