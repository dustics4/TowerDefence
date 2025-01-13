using Godot;
using Godot.NativeInterop;
using System;


public partial class Enemy : RigidBody2D
{
	public Area2D tower;
	private Health health;
	private Vector2 _targetPosition;
    private static PackedScene enemyScene = GD.Load<PackedScene>("res://Scenes/Enemy.tscn");
	private bool reachedTower = false;

	
	public Enemy()
	{
		health = new Health();
		health.MaxHealth = 100;
		health.MaxHealth = health.CurrentHealth;
		health.Damage = 10f;
		GD.Print("Health initalized with MaxHealth : ", health.MaxHealth);
	}

	public void PrintEnemyHealth()
	{	
		GD.Print($"Current health : {health.CurrentHealth} ");
	}

	public void PrintEnemyDamage()
	{	
		GD.Print($"Current Damage : {health.Damage} ");
	}

	public void PrintEnemyName()
	{	
		GD.Print($"Current Name : {health.Name} ");
	}
	
	public void Movement()
	{
		if (tower == null)
		{
			GD.PrintErr("Tower reference is null!");
			return;
		}

		if(reachedTower)
		{
			return;
		}

		 // Move towards the tower
        Vector2 direction = (tower.GlobalPosition - GlobalPosition).Normalized();
        float speed = 100f; // Adjust the movement speed as needed
        GlobalPosition += direction * speed * (float)GetProcessDeltaTime();
		DistanceToTower();
	}

	public void DistanceToTower()
	{
		float distanceToTower = GlobalPosition.DistanceTo(tower.GlobalPosition);
		if(distanceToTower <= 10f )
		{
			reachedTower = true;
			GD.Print($"{Name} has stopped moving at {GlobalPosition}");
		}
	}

	public static Enemy NewEnemy(int _health, float _damage, string _name)
	{
		var newEnemy = enemyScene.Instantiate<Enemy>();
		newEnemy.health.MaxHealth = _health;
		newEnemy.health.CurrentHealth = newEnemy.health.MaxHealth;
		newEnemy.health.Damage = _damage;
		newEnemy.Name = _name;
		return newEnemy;
	}

	public void SpawnPosition(Vector2 _vector)
	{
		GlobalPosition = _vector;
	}

	public void OnEnemyDeath()
	{
		
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
