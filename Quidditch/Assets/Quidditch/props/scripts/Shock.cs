using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock : MonoBehaviour
{
    private Transform father;
    // Start is called before the first frame update
    void Start()
    {
        father = gameObject.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = father.position + new Vector3(0,0.2f,0);
    }
}
