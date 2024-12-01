using Godot;
using System;
using System.Numerics;

public partial class Tower : Node2D
{
    // Called when the node enters the scene tree for the first time.

    public override void _Draw()
    {
		DrawLine(new Godot.Vector2(1.5f, 1.0f), new Godot.Vector2(1.5f, 4.0f), Colors.Green, 1.0f);
		DrawLine(new Godot.Vector2(4.0f, 1.0f), new Godot.Vector2(4.0f, 4.0f), Colors.Green, 3.0f);
		DrawLine(new Godot.Vector2(7.5f, 1.0f), new Godot.Vector2(7.0f, 4.0f),Colors.Green, 3.0f );
		DrawRect(new Rect2(16.0f, 2.0f, 3.0f, 3.0f), Colors.Green, false, 2.0f);
        base._Draw();
    }
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		QueueRedraw();
	}
}
