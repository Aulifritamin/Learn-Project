using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private Score _score;

    private string _prefix = "Score: ";
    private int _startedScore = 0;

    private void Start()
    {
        _label.text = _prefix + _startedScore;
    }

    private void OnEnable()
    {
        _score.ScoreChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _score.ScoreChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _label.text = _prefix + value;
    }
}
