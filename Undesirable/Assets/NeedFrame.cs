using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedFrame : MonoBehaviour
{
    public Transform playerTransform;

    //相机跟随
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //相机跟随
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //相机跟随
        transform.position = playerTransform.position + offset;
    }
}
