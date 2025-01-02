using Godot;
using System;
using System.Collections.Generic;

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
        Vector2 pos = new Vector2(200, 200);
        Vector2 pos2 = new Vector2(300, 200);
        Enemy enemy = new Enemy(_maxHealth);
        Enemy enemy2 = new Enemy(_maxHealth , 100f);
        Enemies.Add(enemy);
        Enemies.Add(enemy2);
        GD.Print($"enemy1 Damage : {0}, enemy2 Damage: {1}", enemy.Damage.ToString(), enemy2.Damage.ToString());
        SpawnEnemy(enemy, pos);
        SpawnEnemy(enemy2 , pos2);
        GD.Print($"Enemy1 at position {0} ||  enemy2 at position {1}", enemy.Position, enemy2.Position);
    }

    public void SpawnEnemy(Enemy _enemy, Vector2 _position)
    {
        
        _enemy.Body.Position = _position;
        AddChild(_enemy);

    }
}