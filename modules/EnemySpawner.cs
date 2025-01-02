using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

public partial class EnemySpawner : Node
{   
    // pass enemy , within class to add into enemyspawner
    public List<Enemy> Enemies = new List<Enemy>(); // creates an array of enemy
    // colide with other enemies
    // movement enemy
    // what happens when enemy hits tower.


    public EnemySpawner()
    {
        
    }

    public void CreateEnemy(int _maxHealth)
    {   
        int amount = 1; //Creating amount of enemies
        int secondAmount = 2;
        
        Vector2 pos = new Vector2(200, 200f); //Setting possition for enemy
        Vector2 pos2 = new Vector2(300, 200f);
        
        Enemy enemy = new Enemy(_maxHealth); //ICreating instance of enemy
        Enemy enemy2 = new Enemy(_maxHealth , 100f);
        

        Enemies.Add(enemy); // Adding enemy to the list
        Enemies.Add(enemy2);
        
        GD.Print($"enemy1 Damage : {0}, enemy2 Damage: {1}", enemy.Damage.ToString(), enemy2.Damage.ToString());
        GD.Print($"Enemy1 at position {0} ||  enemy2 at position {1}", enemy.Position, enemy2.Position);

        SpawnEnemy(enemy, pos, amount); // Spawning enemy1 and 2 below
        SpawnEnemy(enemy2 , pos2, secondAmount);
    }

    public void SpawnEnemy(Enemy _enemy, Vector2 _position, int _amount)
    {

        string path = "res://Scenes/Enemy.tscn";
        GD.Print(path);
        for(int i = 0; i < _amount; i++)
        {
            _enemy.GlobalPosition = _position;
        }
       
    }
}