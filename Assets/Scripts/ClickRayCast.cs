using UnityEngine;

public class ClickRayCast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 100f;

    private void Update()
    {
        InputCheck();
    }

    private void InputCheck()
    {
        int keyAction = 0;

        if(Input.GetMouseButtonDown(keyAction)) 
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _maxDistance))
            {
                hitInfo.rigidbody?.GetComponent<Generate>()?.ExecuteAction();
            }
        }
    }
}
