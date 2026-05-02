using Unity.Behavior;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    [SerializeField] Animator animator;
    public static bool isBattleMusic = false;
    private void Update() => animator.SetBool("IsBattleMusic", isBattleMusic);
}
