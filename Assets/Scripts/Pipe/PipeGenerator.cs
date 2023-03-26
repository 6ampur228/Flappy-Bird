using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;

    [SerializeField] private int _timeBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private float _elepsedTime;

    private void Start()
    {
        _elepsedTime = _timeBetweenSpawn;

        Initialize(_template);
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if(_elepsedTime >= _timeBetweenSpawn)
        {
            if (TryGetObject(out GameObject pipe))
            {
                _elepsedTime = 0;

                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);

                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;

                DisableObjectAbroadScreen();
            }
        }        
    }
}
