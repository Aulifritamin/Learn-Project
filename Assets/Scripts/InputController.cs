using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action Clicked;

    private int _ClickLeftButton = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_ClickLeftButton)) 
        {
            Clicked?.Invoke();
        }
    }
}
