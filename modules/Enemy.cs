using Godot;
using System;

public partial class Enemy : RigidBody2D
{
	public int CurrentHealth;
	public int MaxHealth;
	public float Damage = 0f;


	public Enemy(int _maxHealth)
	{
		MaxHealth = _maxHealth;
		CurrentHealth = MaxHealth;
		Damage = 10f;
	}

	public Enemy(int _maxHealth, float _damage)
	{
		MaxHealth = _maxHealth;
		CurrentHealth = MaxHealth;
		Damage = _damage;
	}

	public void PrintEnemyHealth()
	{	
		GD.Print($"Current health : {0} ", CurrentHealth);
	}
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PrintEnemyHealth();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
