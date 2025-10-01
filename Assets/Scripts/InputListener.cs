using System;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    private int keyAction = 0;

    public event Action<Vector2> OnInputReceived;
   
    private void Update()
    {
        if (Input.GetMouseButtonDown(keyAction))
        {
            Vector2 mousePosition = Input.mousePosition;
            
            OnInputReceived?.Invoke(mousePosition);
        }
    }
}
