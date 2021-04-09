using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleIsoConstructor1 : MonoBehaviour
{
    public GameObject brickPfb;
    public int width = 5;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < width; j++) 
            {
                if (j <= i) 
                {
                    GameObject brick = Instantiate(brickPfb, transform.position + new Vector3(i, j, 0f), Quaternion.identity);
                    brick.transform.SetParent(transform);
                    if (j % 2 == 1)
                    {
                        brick.GetComponent<Renderer>().material.color = Color.red;
                    }
                }
            }
        }
    }
}
