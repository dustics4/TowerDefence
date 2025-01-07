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

    public Area2D tower;
    // colide with other enemies
    // movement enemy
    // what happens when enemy hits tower.

    private Node2D spawnPoint;

    public EnemySpawner()
    {
        
    }

    public void SetupEnemy()
    {   
               
    }

    public void SpawnEnemy(int _health , float _damage, string _name)
    {
        Enemy enemy = Enemy.NewEnemy(_health, _damage, _name);
        
        Enemies.Add(enemy);
        AddChild(enemy);

        var rng = new RandomNumberGenerator();
        var i = rng.RandiRange(0,3);
        var point = spawns[i];
        enemy.Position = point.Position;

        enemy.tower = tower;
        GD.Print($"Enemy : {enemy.Name} , Spawned : {point.Name}" );
        
    }

    public void CreateSpawnPoints()
    {
        string name = "Spawnpoint";
        coords.Add(new Vector2(-50, 360)); // Left of the window
        coords.Add(new Vector2(530, 360)); // Right of the window
        coords.Add(new Vector2(240, -50)); // Above the window
        coords.Add(new Vector2(240, 770)); // Below the window

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

    public void spawnEnemies(int _amount, string _name)
    {   
        
        for(int i = 0; i < _amount; i++)
        {
            string name = _name + i;
            SpawnEnemy(100, 10f, name);
        }
    }

    public void PrintEnemyValues()
    {
         foreach (Enemy enemy1 in Enemies)
        {
            GD.Print($"Enemy: HP {enemy1.MaxHealth} , DMG : {enemy1.Damage} , Name : {enemy1.Name}");
        }
    }

    public override void _Ready()
    {
     	tower = GetParent().GetNode<Area2D>("Tower");
        CreateSpawnPoints();
        //SpawnEnemy(100, 10f, "Name1");
        //SpawnEnemy(200, 10f, "Destroyer");
        spawnEnemies(4, "Destroyer");
        PrintEnemyValues();
        
       
        
    }


}