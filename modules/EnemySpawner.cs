using Godot;
using System;
using System.Collections.Generic;

public class EnemySpawner
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
        Enemy enemy = new Enemy(_maxHealth);
        Enemy enemy2 = new Enemy(_maxHealth , 100);
        Enemies.Add(enemy);
        Enemies.Add(enemy2);
        GD.Print(enemy.Damage, enemy2.Damage);
    }
}