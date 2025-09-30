using System;
using UnityEngine;

public class CubeSplit : MonoBehaviour
{
     [SerializeField] private float _splitChance = 1f;

     public float SplitChance => _splitChance;
     
     public void SetSplitChance(float value)
     {
          _splitChance = value;
     }
}
