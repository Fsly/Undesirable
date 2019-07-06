using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpProps : MonoBehaviour
{

    public Image image;
    public Sprite sp;

    public float startTime;

    public bool isStartTime = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartTime)
        {
            startTime -= Time.deltaTime;
            if (startTime <= 0)
            {
                isStartTime = false;
                //显示对号
                image.sprite = sp;
            }
        }
    }

    //碰撞检测
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Prop")
        {
            Destroy(collider.gameObject);
            isStartTime = true;
        }
    }
}
