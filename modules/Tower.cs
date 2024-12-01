using Godot;
using System;

public partial class Tower : Node2D
{
    // Called when the node enters the scene tree for the first time.

    public override void _Draw()
    {
		DrawLine(new Vector2(1.5f, 1.0f), new Vector2(1.5f, 4.0f), Colors.Green, 1.0f);
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
