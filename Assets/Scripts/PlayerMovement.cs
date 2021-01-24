using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int maxRange = 5;
    // Update is called once per frame
    void Update()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 o = transform.position;

        transform.position = new Vector3(o.x, Mathf.Clamp(p.y, -maxRange, maxRange), o.z);
    }
}
