using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleIsoConstructor2 : MonoBehaviour
{
    public GameObject brickPfb;
    public int width = 5;
    public Vector3 brickScale;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < width; j++) 
            {
                if (j <= i) 
                {
                    GameObject brick = Instantiate(brickPfb, transform.position + new Vector3(i*brickScale.x, j*brickScale.y, 0f), Quaternion.identity);
                    brick.transform.localScale = brickScale;
                    brick.transform.SetParent(transform);
                    if (i%2 == j%2)
                    {
                        brick.GetComponent<Renderer>().material.color = Color.red;
                    }
                }
            }
        }
    }
}
