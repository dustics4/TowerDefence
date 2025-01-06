using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

public partial class EnemySpawner : Node
{   
    // pass enemy , within class to add into enemyspawner
    public List<Enemy> Enemies = new(); // creates an array of Enemy
    public List<Node2D> spawns = new();
    private List<Vector2> coords = new();
    // colide with other enemies
    // movement enemy
    // what happens when enemy hits tower.

    private Node2D spawnPoint;

    private PackedScene enemyScene = GD.Load<PackedScene>("res://Scenes/Enemy.tscn");
    public EnemySpawner()
    {
        
    }

    public void SetupEnemy()
    {   
               
    }

    public void SpawnEnemy()
    {
        Enemy enemy = enemyScene.Instantiate() as Enemy;
        enemy.Name = "Enemy" + Enemies.Count;
        Enemies.Add(enemy);
        AddChild(enemy);
        enemy.Init(100, 10f);
        var rng = new RandomNumberGenerator();
        var i = rng.RandiRange(0, 3);
        var point = spawns[i];
        enemy.Position = point.Position;
        GD.Print($"Enemy : {0} , @Spawned : {1}", enemy.Name, point.Name);
    }

    public void CreateSpawnPoints()
    {
        string name = "Spawnpoint";
        for(int i = 0; i < 4; i++)
        {
            spawnPoint = new();
            spawnPoint.Name = name + i;
            AddChild(spawnPoint);
            spawns.Add(spawnPoint);
            AssignCoordinates();
        }
    }

    public void AssignCoordinates()
    {
        for(int i = 0; i < spawns.Count ; i++)
        {
            spawns[i].Position = coords[i];
        }
    }

    public void spawnEnemies(int _amount)
    {   
        for(int i = 0; i < _amount; i++)
        {
            SpawnEnemy();
        }
    }

    public override void _Ready()
    {
        coords.Add(new Vector2(200,100));
        coords.Add(new Vector2(300,100));
        coords.Add(new Vector2(250,150));
        coords.Add(new Vector2(250,200));
        CreateSpawnPoints();
        spawnEnemies(4);
        
    }


}