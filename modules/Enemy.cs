using Godot;
using Godot.NativeInterop;
using System;


public partial class Enemy : RigidBody2D
{
	public Area2D tower;
	public int CurrentHealth;
	public int MaxHealth;
	public float Damage = 0f;
	private Vector2 _targetPosition;
    private static PackedScene enemyScene = GD.Load<PackedScene>("res://Scenes/Enemy.tscn");
	private bool reachedTower = false;


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
		if (tower == null)
		{
			GD.PrintErr("Tower reference is null!");
			return;
		}

		 // Move towards the tower
        Vector2 direction = (tower.GlobalPosition - GlobalPosition).Normalized();
        float speed = 100f; // Adjust the movement speed as needed
        GlobalPosition += direction * speed * (float)GetProcessDeltaTime();

		GD.Print($"Moving towards tower at {GlobalPosition}");

		float distanceToTower = GlobalPosition.DistanceTo(tower.GlobalPosition);
		if(distanceToTower <= 10f)
		{
			reachedTower = true;
			GD.Print($"{Name} has stopped moving at {GlobalPosition}");
		}
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
		Movement();
	}
}
