using Godot;
using System;

public partial class Enemy : RigidBody2D
{
	public int CurrentHealth;
	public int MaxHealth;
	public float Damage = 0f;
	public RigidBody2D Body;
	private Vector2 _targetPosition;


	public Enemy(int _maxHealth)
	{
		MaxHealth = _maxHealth;
		CurrentHealth = MaxHealth;
		Damage = 10f;
		Body = GetNode<RigidBody2D>(".");  
	}

	public Enemy(int _maxHealth, float _damage)
	{
		MaxHealth = _maxHealth;
		CurrentHealth = MaxHealth; 
		Damage = _damage;
		Body = GetNode<RigidBody2D>(".");  
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

	public void Init()
	{	
	
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
