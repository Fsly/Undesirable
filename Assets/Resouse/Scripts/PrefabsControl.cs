using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsControl : MonoBehaviour
{
    public bool isX = false;
    public bool isY = false;
    public bool isZ = false;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isX)
            transform.Rotate(new Vector3(1, 0, 0));
        else if (isY)
            transform.Rotate(new Vector3(0, 1, 0));
        else if (isZ)
            transform.Rotate(new Vector3(0, 0, 1));
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Plane02")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
