using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject Prefab;
    public Transform[] locations;
    private GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
        
        locations = this.GetComponentsInChildren<Transform>();
        foreach(Transform i in locations )
        {
            if (i.name != this.name)
            {
                //Instantiate(Prefab, i);
                clone = Instantiate(Prefab, i);
                clone.GetComponent<Destroyafterspawn>().time = Random.Range(1f, 9f);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
