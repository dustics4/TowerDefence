using Godot;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

[Tool]
public partial class Tower : Area2D
{
	[Signal]
	public delegate void HitEventHandler();

	
	private int health = 100;
	private Label healthLabel;

	private void InitializeHealthLabel()
	{

	}

	private void UpdateHealthLabel()
	{

	}

	private void OnBodyEntered(Node2D body)
	{
		Hide();
		EmitSignal(SignalName.Hit);
		GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled , true);
	}

	public void Start(Vector2 position)
	{
		Position = position;
		Show();
		EnableCollision();
	}
	
    public override void _Ready()  // Called when the node enters the scene tree for the first time.
	{
		GD.Print("Tower with health  :" + health);
	}

	private void EnableCollision()
	{
		var collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
		collisionShape.Disabled = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		QueueRedraw();
	}
}
