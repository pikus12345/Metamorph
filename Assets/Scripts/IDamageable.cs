using UnityEngine;

public interface IDamageable
{
    public void Hurt(int amount);
}
public interface IHealable
{
    public void Heal(int amount);
}