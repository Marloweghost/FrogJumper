using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour, IService
{
    [SerializeField] private float distanceBetweenLanes = 2f;

    private PlayerLane currentLane = new PlayerLane();

    public int GetCurrent()
    {
        return currentLane.Get();
    }

    public void MoveToAdjacentLeft()
    {
        currentLane.MoveToAdjacentLeft();
    }

    public void MoveToAdjacentRight()
    {
        currentLane.MoveToAdjacentRight();
    }

    public float GetDistance()
    {
        return distanceBetweenLanes;
    }
}
