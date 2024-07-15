using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Environment : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 0f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float step = moveSpeed * Time.deltaTime;
        Vector3 targetPosition = transform.position + -Vector3.forward;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
