using Godot;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

[Tool]
public partial class Tower : Area2D
{
 
	int health = 100;


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
		QueueRedraw();

	}
}
