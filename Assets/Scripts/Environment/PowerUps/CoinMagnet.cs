using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class CoinMagnet : MonoBehaviour
{
    private float pullForce = 5f;
    private float pullRadius = 5f;
    private bool isInitialized = false;

    public void Initialize(float _pullForce, float _pullRadius)
    {
        pullForce = _pullForce;
        pullRadius = _pullRadius;

        GetComponent<SphereCollider>().radius = pullRadius;

        isInitialized = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (isInitialized)
        {
            if (other.TryGetComponent(out ICollectable _collectable))
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, transform.position, pullForce);
            }
        }
        else
        {
            Debug.Log("CoinMagnet is not initialized!");
        }
    }

}
