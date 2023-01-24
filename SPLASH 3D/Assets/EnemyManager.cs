using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemyInSight = new List<Enemy>();

    public void AddEnemy(Enemy enemy){
        enemyInSight.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy){
        enemyInSight.Remove(enemy);
    }
}
