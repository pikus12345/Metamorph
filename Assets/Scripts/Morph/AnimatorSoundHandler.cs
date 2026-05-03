using StarterAssets;
using UnityEngine;

public class AnimatorSoundHandler : MonoBehaviour
{
    [SerializeField] private AudioSource footstep;
    [SerializeField] private AudioSource attack;

    [SerializeField] private AttackController attackController;

    public void OnEvent(AnimationEvent e)
    {
        if(e.intParameter == 0)
            footstep?.Play();
        else if(e.intParameter == 1)
        {
            attack?.Play();
            attackController?.DoDamage();
        }
    }
}
