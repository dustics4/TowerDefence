using Godot;
using System;

public partial class Main : Node
{	
	private EnemySpawner _enemySpawner = new EnemySpawner();
	//private Enemy _enemy = new Enemy(100);
	//private Vector2 pos = new Vector2(100, 100);

	// Called when the node enters the scene tree for the first time.

	public override void _Ready()
	{
		//_enemySpawner.SpawnEnemy(_enemy, pos);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	/// 

}
