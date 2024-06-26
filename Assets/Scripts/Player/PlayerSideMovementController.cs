using System.Collections;
using UnityEngine;

public class PlayerSideMovementController : MonoBehaviour
{
    [SerializeField] private float distanceBetweenLanes = 4f;

    private PlayerLaneStateMachine playerLaneStateMachine = new PlayerLaneStateMachine();
    private float defaultX;
    private float newPositionX;

    private void Start()
    {
        defaultX = transform.position.x;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerLaneStateMachine.CurrentLane -= 1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            playerLaneStateMachine.CurrentLane += 1;
        }

        float _desiredX = defaultX + (((int)playerLaneStateMachine.CurrentLane - 1) * distanceBetweenLanes);

        newPositionX = _desiredX;

        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
