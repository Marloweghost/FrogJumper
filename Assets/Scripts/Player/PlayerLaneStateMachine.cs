using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaneStateMachine
{
    public enum State
    {
        Left,
        Center,
        Right,
    }

    private State currentLane = (State)1;
    public State CurrentLane
    {
        get
        {
            return currentLane;
        }
        set
        {
            if (value < 0)
            {
                currentLane = 0;
            }
            else if ((int)value > 2)
            {
                currentLane = (State)2;
            }
            else currentLane = value;
        }
    }
}
