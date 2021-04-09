using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallConstructor : MonoBehaviour
{
    public GameObject brickPfb;
    public int height = 5;
    public int width = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++) 
            {
                Instantiate(brickPfb, new Vector3(i, j, 0f), Quaternion.identity, transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
