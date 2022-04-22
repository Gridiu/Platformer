using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PigMovement : MonoBehaviour
{
    private const float Speed = 1.5f;
 
    [SerializeField] private Transform _path;

    private Transform[] _pathPoints;
    private int _currentPoint;

    private UnityEvent _pigRightRunning = new UnityEvent();
    private UnityEvent _pigLeftRunning = new UnityEvent();

    public event UnityAction PigRightRunning
    {
        add => _pigRightRunning.AddListener(value);
        remove => _pigRightRunning.RemoveListener(value);
    }

    public event UnityAction PigLeftRunning
    {
        add => _pigLeftRunning.AddListener(value);
        remove => _pigLeftRunning.RemoveListener(value);
    }

    private void Start()
    {
        _pathPoints = new Transform[2];

        for (int i = 0; i < _path.childCount; i++)
        {
            _pathPoints[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;

        int firstPointIndex = 0;

        Transform targetPoint = _pathPoints[_currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, Speed * Time.deltaTime);

        if (transform.position.x == targetPoint.position.x)
        {
            _currentPoint++;

            if (_currentPoint == _pathPoints.Length)
            {
                _currentPoint = firstPointIndex;

                _pigLeftRunning.Invoke();
            }
            else
            {
                _pigRightRunning.Invoke();
            }
        }
    }
}
