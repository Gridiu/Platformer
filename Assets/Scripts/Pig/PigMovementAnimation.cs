using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PigMovement))]

public class PigMovementAnimation : MonoBehaviour
{
    private const string IsRunningLeft = "IsRunningLeft";
    private const string IsRunningRight = "IsRunningRight";

    private Animator _animator;
    private PigMovement _pigMovement;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _pigMovement = GetComponent<PigMovement>();
        _pigMovement.PigRightRunning += ChangeAnimationOnRigthMovement;
        _pigMovement.PigLeftRunning += ChangeAnimationOnLeftMovement;
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
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
