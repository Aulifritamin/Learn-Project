using UnityEngine;
[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class CubeSplit : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1f;

    private Renderer _renderer;
    private Rigidbody _rigidbody;

    public float SplitChance => _splitChance;
    public Rigidbody Rigidbody => _rigidbody;
    public Renderer Renderer => _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetSplitChance(float value)
    {
        _splitChance = value;
    }
    
    public void ApplyColor(Color color)
    {
        _renderer.material.color = color;
    }
}
