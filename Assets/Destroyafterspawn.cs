﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyafterspawn : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
