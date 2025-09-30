using UnityEngine;
using System.Collections.Generic;

public class Orchestrator : MonoBehaviour
{
    [SerializeField] private GameEvent _event;
    [SerializeField] private ChildsSpawner _spawner;
    [SerializeField] private Explosion _explosion;

    [SerializeField] private float _childSplitMultiplier = 0.5f;
    [SerializeField] private float _minScale = 0.1f;
    [SerializeField] private float _scaleFactor = 0.5f;

    [SerializeField] private int _minChild = 2;
    [SerializeField] private int _maxChild = 6;

    private void OnEnable()
    {
        _event.CubeClicked += OnCubeClicked;
    }

    private void OnDisable()
    {
        _event.CubeClicked -= OnCubeClicked;
    }

    private void OnCubeClicked(CubeSplit cube)
    {
        
        float randomSplit = Random.value;

        if (cube.transform.localScale.x < _minScale)
        {
            _spawner.Despawn(cube);
            return;
        }

        if (randomSplit <= cube.SplitChance)
        {
            int randomItemCount = Random.Range(_minChild, _maxChild + 1);

            _explosion.AppleExplosion(_spawner.ChildSpawn(cube, _childSplitMultiplier, randomItemCount, _scaleFactor), cube.transform.position);
            _spawner.Despawn(cube);
        }
        else
        {
            _spawner.Despawn(cube);
        }
    }
}
