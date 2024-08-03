using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingGameState : GameState
{
    public PlayingGameState(EventBus _eventBus) : base(_eventBus)
    {
        eventBus = _eventBus;
    }

    public override void Init()
    {
        throw new System.NotImplementedException();
    }
}
