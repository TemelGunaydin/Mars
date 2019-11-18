using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    
    private Material mat;
    private float offset;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += 0.001f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
