using System;
using UnityEngine;

public class ClickRayCast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 100f;
    [SerializeField] private InputListener _inputListener;

    public event Action<CubeSplit> RaiseCube;

    private void OnEnable()
    {
        _inputListener.OnInputReceived += InputCheck;
    }

    private void OnDisable()
    {
        _inputListener.OnInputReceived -= InputCheck;
    }

    private void InputCheck(Vector2 screenPosition)
    {
        if (RaiseCube == null) return;

            Ray ray = _camera.ScreenPointToRay(screenPosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _maxDistance))
            {
                if (hitInfo.collider.TryGetComponent(out CubeSplit cube))
                {
                    RaiseCube(cube);
                }
            }
    }
}
