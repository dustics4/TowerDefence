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
		var uiNode = GetParent().GetNode<Control>("UI");
		if(uiNode != null)
		{
			GD.Print("UI node found.");
			healthLabel = uiNode.GetNode<Label>("CanvasLayer/Label");
			if(healthLabel == null) 
			{
				GD.Print("Health label not found under  UI/CanvasLayer/Label.");
			}
		}else
		{
			GD.PrintErr("UI node not found");
		}
	}

	private void UpdateHealthLabel()
	{
		if(healthLabel != null){
			healthLabel.Text = $"Health : {health}";
		} else
        {
            GD.Print($"Health : {health} (Health label not found)");
        }
	}

	private void ReduceHealth(int amount)
	{
		health -= amount;
		UpdateHealthLabel();
		GD.Print($"Tower health reduced to {health}");
	}

	private void OnBodyEntered(Node2D body)
	{
		ReduceHealth(10);
		HandleCollisionEffects();
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

		InitializeHealthLabel();
		UpdateHealthLabel();
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
