using Godot;
using System;
using System.Numerics;
using System.Collections.Generic;

[Tool]
public partial class Tower : Node2D
{
	public Godot.Vector2 Point1 {get; set;} = new Godot.Vector2(0f,0f);
	public int Width {get; set;} = 10;
	public Color Color {get; set;} = Colors.Green;

	private Godot.Vector2 _point2;

    public override void _Draw()
    {
		DrawLine(Point1, _point2, Color, Width);
    }
	
    public override void _Ready()  // Called when the node enters the scene tree for the first time.
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Godot.Vector2 mousePosition = GetViewport().GetMousePosition();
		if(mousePosition != _point2){
			_point2 = mousePosition;
			QueueRedraw();
		}

	}
}
