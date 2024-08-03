using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : Environment
{
    private EventBus eventBus;

    private void Start()
    {
        eventBus = ServiceLocator.Instance.Get<EventBus>();
        eventBus.Subscribe<SlowSpeedSignal>(SlowSpeed);
        eventBus.Subscribe<AddSpeedSignal>(AddSpeed);
        eventBus.Subscribe<SetSpeedSignal>(SetSpeed);
    }

    private void SlowSpeed(SlowSpeedSignal _signal)
    {
        moveSpeed -= _signal.slowAmount;
    }

    private void AddSpeed(AddSpeedSignal _signal)
    {
        moveSpeed += _signal.amount;
    }

    private void SetSpeed(SetSpeedSignal _signal)
    {
        moveSpeed = _signal.speed;
    }
}
