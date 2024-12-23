using Godot;
using System;

public partial class Enemy : RigidBody2D
{
	public int CurrentHealth;
	public int MaxHealth;
	public enum EnemyType 
	{
		enemy1,
		enemy2,
		enemy3
		
	};

	private EnemyType enemyType;

	public Enemy(EnemyType _enemyType, int _maxHealth)
	{
		enemyType = _enemyType;
		MaxHealth = _maxHealth;
		CurrentHealth = MaxHealth;
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
