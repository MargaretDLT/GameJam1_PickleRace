using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollPin : MonoBehaviour
{
    public float moveSpeed = 5f;


    private Vector3 targetPosition;
    private bool chasePlayer;

    public void StartChasing(Transform target)
    {
        targetPosition = target.position; // Save position once
        chasePlayer = true;
    }

    void Update()
    {
        if (chasePlayer)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );
        }
    }
}
