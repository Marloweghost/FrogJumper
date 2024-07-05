using System.Collections;
using UnityEngine;

public class PlayerSideMovementController : MonoBehaviour
{
    LaneManager laneManager;

    private float defaultX;
    private float newPositionX;
    
    private void Start()
    {
        laneManager = ServiceLocator.Instance.Get<LaneManager>();
        defaultX = transform.position.x;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            laneManager.MoveToAdjacentLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            laneManager.MoveToAdjacentRight();
        }

        float _desiredX = defaultX + ((laneManager.GetCurrent() - 1) * laneManager.GetDistance());
        newPositionX = _desiredX;

        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
