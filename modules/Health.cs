using Godot;
using System;

public partial class Health : Node
{
    public int CurrentHealth;
    public int MaxHealth;
    public float Damage;
    public Health()
    {
        this.MaxHealth = 100;
        this.CurrentHealth = this.MaxHealth;
        this.Damage = 10f;
    }

    public void TakeDamage()
    {

    }
}