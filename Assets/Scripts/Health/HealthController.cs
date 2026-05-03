using System;
using Unity.Collections;
using UnityEngine;

public class Health
{
    public Health(int hp, int maxHP)
    {
        this.hp = hp;
        this.maxHP = maxHP;
        ClampHealth();
    }
    private int maxHP;
    private int hp;
    public int HP => hp;

    /// <summary>
    /// Action<hp, maxHP></hp>
    /// </summary>
    public event Action<int, int> OnHealthChanged;
    public event Action OnDie;

    public void Heal(int amount)
    {
        hp += amount;
        ClampHealth();
    }
    public void Hurt(int amount)
    {
        hp -= amount;
        ClampHealth();
    }
    private void ClampHealth()
    {
        hp = Mathf.Clamp(hp, 0, maxHP);
        OnHealthChanged?.Invoke(hp, maxHP);
        if (hp <= 0)
            Die();
    }
    private void Die()
    {
        OnDie?.Invoke();
    }
}
public class HealthController : MonoBehaviour, IDamageable, IHealable
{
    private Health health;

    

    [Header("Health Settings")]
    [SerializeField][ReadOnly] private int currentHealth;
    [SerializeField] private int maxHealth;

    [Header("Display")]
    [SerializeField] private HealthDisplayer displayer;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource hurtAudio;
    [SerializeField] private AudioSource healAudio;
    [SerializeField] private AudioSource deathAudio;

    public event Action OnDie;
    private void RefreshDisplay(int hp, int maxHP)
    {
        currentHealth = hp;
        maxHealth = maxHP;
        displayer?.Display(hp, maxHP);
    }
    private void Awake()
    {
        health = new Health(currentHealth, maxHealth);
        RefreshDisplay(currentHealth, maxHealth);
    }
    private void OnEnable()
    {
        health.OnHealthChanged += RefreshDisplay;
        health.OnDie += Die;
    }
    private void OnDisable()
    {
        health.OnHealthChanged -= RefreshDisplay;
        health.OnDie += Die;
    }
    private void Die()
    {
        OnDie?.Invoke();
        deathAudio.Play();
        Destroy(gameObject);
        Destroy(this);
    }
    public void Hurt(int amount) 
    {
        hurtAudio?.Play();
        health.Hurt(amount); 
    }
    public void Heal(int amount) 
    {
        if(healAudio != null)
            healAudio.Play();
        health.Heal(amount);
    }
}
