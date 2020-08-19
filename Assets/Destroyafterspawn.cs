using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyafterspawn : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        FunctionTimer.Create(() => Destroy(this.gameObject), time);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
