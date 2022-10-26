using System;
public interface IHealth
{
    int Health { get; set; }

    public void Damage(int damage);

    public Action OnDeath { get; set; }

}