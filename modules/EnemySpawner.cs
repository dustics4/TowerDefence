using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

public partial class EnemySpawner : Node
{   
    // pass enemy , within class to add into enemyspawner
    public List<Enemy> Enemies = new(); // creates an array of Enemy
    public List<Node2D> spawns = new();
    // colide with other enemies
    // movement enemy
    // what happens when enemy hits tower.

    private Node2D spawnPoint;

    private PackedScene enemyScene = GD.Load<PackedScene>("res://Scenes/Enemy.tscn");
    public EnemySpawner()
    {
        
    }

    public void CreateEnemy(int _maxHealth)
    {   
        Vector2 pos = new Vector2(200, 200f); //Setting possition for enemy
        Vector2 pos2 = new Vector2(300, 200f);
        
    }

    public void SpawnEnemy()
    {
        Enemy enemy = enemyScene.Instantiate() as Enemy;
        enemy.Name = "Enemy" + Enemies.Count;
        Enemies.Add(enemy);
        AddChild(enemy);
        enemy.Init(100, 10f);
    }

    public void CreateSpawnPoints()
    {
        string name = "Spawnpoint";
        for(int i = 0; i < 4; i++)
        {
            spawnPoint = new();
            spawnPoint.Name = name + i;
            AddChild(spawnPoint);
            
        }
    }


}