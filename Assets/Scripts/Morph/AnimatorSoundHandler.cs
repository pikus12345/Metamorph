using StarterAssets;
using UnityEngine;

public class AnimatorSoundHandler : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public void OnEvent(AnimationEvent e)
    {
        audioSource.Play();
    }
}
