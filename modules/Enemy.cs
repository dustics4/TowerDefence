using Godot;
using Godot.NativeInterop;
using System;


public partial class Enemy : RigidBody2D
{
	public int CurrentHealth;
	public int MaxHealth;
	public float Damage = 0f;
	private Vector2 _targetPosition;
    private static PackedScene enemyScene = GD.Load<PackedScene>("res://Scenes/Enemy.tscn");


	public Enemy()
	{
		this.MaxHealth = 100;
		this.CurrentHealth = this.MaxHealth;
		this.Damage = 10f;
		this.Name = " ";
	}

	public void PrintEnemyHealth()
	{	
		GD.Print($"Current health : {0} ", CurrentHealth);
	}

	public void Movement()
	{
		//reference tower position.  _tower = GetParent().GetNode<Area2D>("Tower");
		// We need to enemy after spawning to move from coodrinates to tower global position.
	}

	public static Enemy NewEnemy(int _health, float _damage, string _name)
	{
		var newEnemy = enemyScene.Instantiate<Enemy>();
		newEnemy.MaxHealth = _health;
		newEnemy.CurrentHealth = newEnemy.MaxHealth;
		newEnemy.Damage = _damage;
		newEnemy.Name = _name;
		return newEnemy;
	}

	public void SpawnPosition(Vector2 _vector)
	{
		GlobalPosition = _vector;
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
