using Godot;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

[Tool]
public partial class Tower : Area2D
{
	[Signal]
	public delegate void HitEventHandler();
	 
	[Export]	
	public int CurrentHealth;
	public int MaxHealth;
	public float Damage = 0f;

	private Label healthLabel;
	public bool gameOver;

	public Tower()
	{
		this.MaxHealth = 100;
		this.CurrentHealth = this.MaxHealth;
		this.Damage = 15;
	}
	public void _on_body_entered(Node2D body)
	{
		
	}
	private void InitializeHealthLabel()
	{
		var uiNode = GetParent().GetNode<Control>("Control"); 
		healthLabel = uiNode.GetNode<Label>("CanvasLayer/Label");
	
	}

	

	private void ReduceHealth(int amount)
	{
		
	}

	public void Start(Vector2 position)
	{
		Position = position;
		Show();
	}
	
    public override void _Ready()  // Called when the node enters the scene tree for the first time.
	{
		
	}

	private void HandleCollisionEffects()
	{
		Hide();
		EmitSignal(SignalName.Hit);
		GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled , true);
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
