using UnityEngine;
using System.Collections.Generic;

public class Orchestrator : MonoBehaviour
{
    [SerializeField] private ClickRayCast _rayCast;
    [SerializeField] private ChildsSpawner _spawner;
    [SerializeField] private ChildImpulse _impulse;
    [SerializeField] private RadialExplosion _explosion;

    [SerializeField] private float _minScale = 0.1f;


    private void OnEnable()
    {
        _rayCast.CubeHit += OnCubeClicked;
    }

    private void OnDisable()
    {
        _rayCast.CubeHit -= OnCubeClicked;
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
            List<Rigidbody> childrensRigidbody = _spawner.SpawnChildren(cube);

            _impulse.AppleExplosion(childrensRigidbody, cube.transform.position);
        }
        else
        {
            _explosion.Boom(cube);
        }

        _spawner.Despawn(cube);
    }
}
