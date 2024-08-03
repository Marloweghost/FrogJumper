using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObstacle : Environment, ICollidable
{
    public void Collide()
    {
        var eventBus = ServiceLocator.Instance.Get<EventBus>();
        //eventBus.Invoke(// Invulnerability and remove some health);
    }
}
