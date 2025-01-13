using Godot;
using System;

public partial class Health : Node
{
    [Signal]
    public delegate void HealthChangedEventHandler();
    [Signal]
    public delegate void OnDeathEventHandler();
    public int CurrentHealth;
    public int MaxHealth;
    public float Damage;
    public Health()
    {
        this.MaxHealth = 100;
        this.CurrentHealth = this.MaxHealth;
        this.Damage = 10f;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;

        EmitSignal(nameof(HealthChanged)); // This should trigger when the health changes

        if(CurrentHealth <= 0) // This triggers when health is 0 or below
        {
            EmitSignal(nameof(OnDeath));
        }
    }
    
}