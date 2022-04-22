using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HumanMovement))]

public class HumanMovementAnimation : MonoBehaviour
{
    private const string IsRunningLeft = "IsRunningLeft";
    private const string IsRunningRight = "IsRunningRight";
    private const string IsIdle = "IsIdle";

    private Animator _animator;
    private HumanMovement _humanMovement;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _humanMovement = GetComponent<HumanMovement>();
        _humanMovement.HumanRightRunning += ChangeAnimationOnRigthMovement;
        _humanMovement.HumanLeftRunning += ChangeAnimationOnLeftMovement;
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool(IsRunningLeft, false);
            _animator.SetBool(IsRunningRight, false);
            _animator.SetBool(IsIdle, true);
        }
    }

    private void ChangeAnimationOnRigthMovement()
    {
        _animator.SetBool(IsRunningLeft, false);
        _animator.SetBool(IsRunningRight, true);
    }

    private void ChangeAnimationOnLeftMovement()
    {
        _animator.SetBool(IsRunningRight, false);
        _animator.SetBool(IsRunningLeft, true);
    }
}
