using System;
using UnityEngine;

public class ClickRayCast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 100f;
    [SerializeField] private GameEvent _event;

    private void Update()
    {
        InputCheck();
    }

    private void InputCheck()
    {
        int keyAction = 0;

        if (_event == null) return;
        
        if (Input.GetMouseButtonDown(keyAction))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, _maxDistance))
            {
                if (hitInfo.collider.TryGetComponent(out CubeSplit cube))
                {
                    _event.RaiseCube(cube);
                }
            }
        }
    }
}
