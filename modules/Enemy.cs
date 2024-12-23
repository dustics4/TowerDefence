using Godot;
using System;

public partial class Enemy : RigidBody2D
{
	public int _CurrentHealth;
	public int _MaxHealth;
	public enum _EnemyType 
	{
		enemy1,
		enemy2,
		enemy3
		
	};

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_EnemyType enemyType = new _EnemyType{};

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
