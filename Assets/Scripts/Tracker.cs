using System;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public static event Action OnLeftClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            OnLeftClick?.Invoke();
        }
    }
}
