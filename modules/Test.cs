using Godot;
using System;

public partial class Test : CharacterBody2D
{	
	[Signal]
	public delegate void HitEventHandler();
	

	[Export]
	public int Speed {get; set;} = 200;
	
	public Vector2 _initialPosition;
	public Vector2 _targetPosition;
	public Vector2 _screenSize;
	[Export]
	public Control _healthLabel;

	public Area2D _tower;

	// Called when the node enters the scene tree for the first time.
	
	private void OnBodyEntered(Node2D body)
	{
		if(body == this){
			Hide();
			EmitSignal(SignalName.Hit);
			GD.Print("Test collided with tower");
		}		
	}


	public override void _Ready()
	{
		_screenSize = GetViewportRect().Size;

		_tower = GetParent().GetNode<Area2D>("Tower");
		if (_tower == null)
		{
			GD.PrintErr("Tower node not found!");
		}
		if(_tower != null){
			_tower.BodyEntered += OnBodyEntered;
		} 
	}

	public override void _PhysicsProcess(double delta)
	{
		if(_tower == null){
			return;
		}

		_targetPosition = _tower.GlobalPosition;
		Velocity = (_targetPosition - GlobalPosition).Normalized() * Speed;

		MoveAndSlide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("move_right"))
		{
			velocity.X += 1;
		}

		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= 1;
		}

		if (Input.IsActionPressed("move_down"))
		{
			velocity.Y += 1;
		}

		if (Input.IsActionPressed("move_up"))
		{
			velocity.Y -= 1;
		}

		if (Input.IsActionPressed("reset"))
		{
			GlobalPosition = new Vector2(10,20);
			Velocity = Vector2.Zero;
		}


		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
		}
		Position += velocity * (float)delta;

		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, _screenSize.X),
			y: Mathf.Clamp(Position.Y, 0, _screenSize.Y)
		);
	}
}
