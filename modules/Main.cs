using Godot;
using System;

public partial class Main : Node
{	
	private EnemySpawner _enemySpawner = new EnemySpawner();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_enemySpawner.CreateEnemy(100);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	/// 

}
