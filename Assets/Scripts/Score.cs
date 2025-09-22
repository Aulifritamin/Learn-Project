using System.Collections;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private float timeToIncrease = 0.5f;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private Coroutine _coroutine;

    private int _scoreValue = 0;
    private string _scoreString = "Score: ";

    private void Start()
    {
        _scoreText.text = _scoreString + _scoreValue;
    }

    private void OnEnable()
    {
        Tracker.OnLeftClick += ToggleCorotine;
    }

    private void OnDisable()
    {
        Tracker.OnLeftClick -= ToggleCorotine;
    }

    private void ToggleCorotine()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(InscreaseScore());
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    IEnumerator InscreaseScore()
    {
        while (true)
        {
            _scoreValue++;
            _scoreText.text = _scoreString + _scoreValue;

            yield return new WaitForSeconds(timeToIncrease);
        }
    }
}
