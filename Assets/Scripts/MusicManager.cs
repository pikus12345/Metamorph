using Unity.Behavior;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    [SerializeField] Animator animator;
    [SerializeField] private Transform player;
    private GameObject[] enemies;
    [SerializeField] private float battleMusicDistance = 3f;
    protected override void Awake()
    {
        base.Awake();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    private void Update() 
    { 
        animator.SetBool("IsBattleMusic", DistanceToClosestEnemy() < battleMusicDistance);
    }
    float DistanceToClosestEnemy()
    {
        float minDistance = float.PositiveInfinity;
        foreach (var item in enemies)
        {
            if (item == null) continue;
            float dist = Vector3.Distance(player.position, item.transform.position);
            if (dist < minDistance)
                minDistance = dist;
        }
        return minDistance;
    }
}
