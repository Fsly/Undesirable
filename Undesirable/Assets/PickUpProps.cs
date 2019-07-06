using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpProps : MonoBehaviour
{

    public Image image;
    public Sprite sp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //碰撞检测
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Prop")
        {
            Destroy(collider.gameObject);
            image.sprite = sp;
        }
    }
}
