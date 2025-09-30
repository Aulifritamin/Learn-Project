using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public event Action<CubeSplit> CubeClicked;

    public void RaiseCube(CubeSplit cube) => CubeClicked?.Invoke(cube);
}
