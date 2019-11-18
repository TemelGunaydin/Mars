using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMars : MonoBehaviour
{
    public float rotateSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * rotateSpeed);
    }

}
