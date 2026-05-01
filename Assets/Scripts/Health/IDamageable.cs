using System;
using UnityEngine;

public interface IDamageable
{
    public event Action OnDie;
    public void Hurt(int amount);
}
public interface IHealable
{
    public void Heal(int amount);
}