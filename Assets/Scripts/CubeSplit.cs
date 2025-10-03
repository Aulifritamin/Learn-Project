using UnityEngine;
[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class CubeSplit : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1f;
    [SerializeField] private float _explodeForce = 10f;
    [SerializeField] private float _explodeRadius = 2f;

    public Rigidbody Rigidbody { get; private set; }
    public Renderer Renderer { get; private set; }
    
    public float SplitChance => _splitChance;
    public float ExplodeForce => _explodeForce;
    public float ExplodeRadius => _explodeRadius;

    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }
    
    public void SetSplitChance(float value)
    {
        _splitChance = value;
    }

    public void ApplyColor(Color color)
    {
        Renderer.material.color = color;
    }
    
    public void ChangeExplodeSettings(float force, float radius)
    {
        _explodeForce = force;
        _explodeRadius = radius;
    }

}
