using System.Collections;
using UnityEngine;

public class PlayerSideMovementController : MonoBehaviour
{
    [SerializeField] private float distanceBetweenLanes = 4f;

    private PlayerLane currentLane = new PlayerLane();
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
            currentLane.Lane--;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            currentLane.Lane++;
        }

        float _desiredX = defaultX + ((currentLane.Lane - 1) * distanceBetweenLanes);
        newPositionX = _desiredX;

        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
