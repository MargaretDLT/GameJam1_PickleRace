using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTrigger : MonoBehaviour
{
    public RollPin enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.StartChasing(other.transform);
        }
    }
}
