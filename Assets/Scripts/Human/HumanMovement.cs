using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HumanMovement : MonoBehaviour
{
    private const float Speed = 8f;
    private const float JumpSpeed = 12f;

    private UnityEvent _humanRightRunning = new UnityEvent();
    private UnityEvent _humanLeftRunning = new UnityEvent();

    public event UnityAction HumanRightRunning
    {
        add => _humanRightRunning.AddListener(value);
        remove => _humanRightRunning.RemoveListener(value);
    }

    public event UnityAction HumanLeftRunning
    {
        add => _humanLeftRunning.AddListener(value);
        remove => _humanLeftRunning.RemoveListener(value);
    }

    private void Update()
    {
        float movementAlongAxis = 0;

        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.Translate(Speed * Time.deltaTime, movementAlongAxis, movementAlongAxis);
            _humanRightRunning.Invoke();
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.Translate(-Speed * Time.deltaTime, movementAlongAxis, movementAlongAxis);
            _humanLeftRunning.Invoke();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(movementAlongAxis, JumpSpeed * Time.deltaTime, movementAlongAxis);
        }
    }
}
