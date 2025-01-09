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

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}