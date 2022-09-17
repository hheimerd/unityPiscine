using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

// using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] prefabs;
    public int limit = 5;
    public int spawnInterval = 5;
    
    private List<Enemy> _spawned = new List<Enemy>();
    private void Start()
    {
        InvokeRepeating(nameof(SpawnOne), 1, spawnInterval);
        InvokeRepeating(nameof(CheckDied), 2, spawnInterval);
    }
    
    public bool SpawnOne()
    {
        if (_spawned.Count > limit)
            return false;
        
        var randomIndex = Random.Range(0, prefabs.Length - 1);
        var positionMove = new Vector3(Random.Range(1f, 3f), 0, Random.Range(1f, 3f));
        var newEnemy = Instantiate(prefabs[randomIndex], transform.position + positionMove, transform.rotation);
        _spawned.Add(newEnemy);
        
        return true;
    }

    void CheckDied()
    {
        var died = _spawned.Where(o => o.IsDied()).ToArray();
        foreach (var enemy in died)
        {
            _spawned.Remove(enemy);
            Destroy(enemy.gameObject);
        }
    }
}
