using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public GameObject spawnPoint;
    public float spawnInterval;
    private float _timePassed = 0;
    public Unit spawnUnit;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        _timePassed += Time.deltaTime;
        if (_timePassed >= spawnInterval)
        {
            _timePassed = 0;
            Unit newUnit = Instantiate(spawnUnit);
            newUnit.transform.position = spawnPoint.transform.position;
        }
    }
}
