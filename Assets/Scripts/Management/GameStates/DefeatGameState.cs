using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatGameState : GameState
{
    public DefeatGameState(EventBus _eventBus) : base(_eventBus)
    {
        eventBus = _eventBus;
    }

    public override void Init()
    {
        eventBus.Invoke(new SetSpeedSignal(0f));
        eventBus.Invoke(new SetAllSpawnersStateSignal(false));

        // Open Defeat text popup with a button
    }
}
