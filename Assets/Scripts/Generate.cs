using UnityEngine;

public class Generate : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Rigidbody _rigidbody;

    private int _min = 2;
    private int _max = 6;
    private float _scaleFactor = 0.5f;

    private Vector3 _parentTransofrm;
    private Vector3 _scaledTransform;

    public void Boom()
    {
        _parentTransofrm = transform.localScale;
        _scaledTransform = _parentTransofrm * _scaleFactor;

        Destroy(gameObject);

        int randomCount = Random.Range(_min, _max);

        for (int i = 0; i < randomCount; i++)
        {
            GameObject newObject = Instantiate(_prefab, transform.position, Quaternion.identity);
            newObject.transform.localScale = _scaledTransform;

            Renderer rend = GetComponent<Renderer>();
            rend.material.color = Random.ColorHSV();
        }
    }
}
