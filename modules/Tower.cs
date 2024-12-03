using Godot;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

[Tool]
public partial class Tower : Area2D
{
	[Signal]
	public delegate void HitEventHandler();


	int health = 100;

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
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}
    public override void _Draw()
    {

    }
	
    public override void _Ready()  // Called when the node enters the scene tree for the first time.
	{
		GD.Print("Hello World");	
		GD.Print(health);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionPressed("reset")){
			GD.Print("Wow, you pressed that!");
			Start(Position);
		}
		QueueRedraw();
	}
}
