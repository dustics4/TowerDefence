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
	public CharacterBody2D test;
	
	private int health = 100;
	private Label healthLabel;

	public void _on_body_entered(Node2D body)
	{
		GD.Print($"Body entered: {body.Name}");
		GD.Print("body");
		ReduceHealth(10);
	}
	private void InitializeHealthLabel()
	{
		var uiNode = GetParent().GetNode<Control>("Control");
		if(uiNode != null)
		{
			GD.Print(uiNode);
			healthLabel = uiNode.GetNode<Label>("CanvasLayer/Label");
			if(healthLabel == null) 
			{	
				GD.Print(healthLabel);
				GD.Print("Health label not found under  CanvasLayer/Label.");
			}
		}else
		{
			GD.PrintErr("UI node not found");
			GD.Print(uiNode);
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
		health = health - amount;
		GD.Print("reduce health function ran" + health);
		UpdateHealthLabel();
		GD.Print($"Tower health reduced to {health}");
	}

	public void GameCheckRound()
	{
		if(health == 0)
		{
			GD.Print("Game over!");
		}
	}
	

	public void Start(Vector2 position)
	{
		Position = position;
		Show();
	}
	
    public override void _Ready()  // Called when the node enters the scene tree for the first time.
	{
		var testObject = GetParent().GetNode<CharacterBody2D>("CharacterBody2D");
		GD.Print("Printing test object" + testObject);

		EnableCollision();

		GD.Print("Tower with health  :" + health);
		GD.Print($"Monitoring: {Monitoring}, CollisionMask: {CollisionMask}");
		

		InitializeHealthLabel();
		UpdateHealthLabel();
		GameCheckRound();
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
