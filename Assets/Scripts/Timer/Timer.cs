using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private const float TimerMinValue = 0f;
    private const float TimerMaxValue = 6f;

    [SerializeField] private UnityEvent _reset;

    private float _currentTimeValue;

    private void Start()
    {
        StartCoroutine(NoteTime());
    }

    private IEnumerator NoteTime()
    {
        while (true)
        {
            _currentTimeValue += Time.deltaTime;

            yield return null;

            if (_currentTimeValue >= TimerMaxValue)
            {
                _reset.Invoke();

                _currentTimeValue = TimerMinValue;
            }
        }
    }
}
