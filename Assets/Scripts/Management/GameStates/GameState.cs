using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    protected EventBus eventBus;

    public GameState(EventBus _eventBus)
    {
        eventBus = _eventBus;
    }

    public abstract void Init();
}
