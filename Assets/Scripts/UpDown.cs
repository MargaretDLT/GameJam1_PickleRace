using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float amplitude = 1.5f;
    public float speed = 2f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPos + new Vector3(0, y, 0);
    }
}
