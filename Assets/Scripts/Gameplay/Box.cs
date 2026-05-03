using System;
using UnityEngine;

public class Box : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject content;
    [SerializeField] private AudioSource destroySound;

    public event Action OnDie;
    public void Hurt(int amount)
    {
        if (amount <= 3) return;
        content?.transform.SetParent(null, true);
        content?.SetActive(true);
        destroySound?.Play();
        OnDie?.Invoke();
        Destroy(gameObject);
    }
}
