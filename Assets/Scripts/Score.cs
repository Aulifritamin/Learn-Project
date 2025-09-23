using System;
using System.Collections;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private float _timeToIncrease = 0.5f;
    [SerializeField] private InputController _input;

    public event Action<int> ScoreChanged;

    private Coroutine _coroutine;
    private WaitForSeconds _waitTime;

    private int _scoreValue = 0;

    private void Start()
    {
        _waitTime = new WaitForSeconds(_timeToIncrease);
    }

    private void OnEnable()
    {
        _input.Clicked += ToggleCorotine;
    }

    private void OnDisable()
    {
        _input.Clicked -= ToggleCorotine;
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

    private IEnumerator InscreaseScore()
    {
        while (enabled)
        {
            _scoreValue++;
            ScoreChanged?.Invoke(_scoreValue);

            yield return _waitTime;
        }
    }
}
