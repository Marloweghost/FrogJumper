using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLane
{
    private int lane = 1;
    /// <summary>
    /// 0 - Left, 1 - Center, 2 - Right
    /// </summary>
    private int Lane
    {
        get => lane;
        set
        {
            if (value < 0)
            {
                lane = 0;
            }
            else if (value > 2)
            {
                lane = 2;
            }
            else lane = value;
        }
    }

    public void MoveToAdjacentLeft()
    {
        Lane--;
    }

    public void MoveToAdjacentRight()
    {
        Lane++;
    }

    public int Get()
    {
        return lane;
    }
}
