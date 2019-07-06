using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpProps : MonoBehaviour
{

    public Image image;
    public Sprite sp_right;
    public Sprite sp_need;

    public float waitTime;

    public bool isWaitTime = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //计算冷却
        if (isWaitTime)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                isWaitTime = false;
                waitTime = 1f;
                //显示道具
                image.sprite = sp_need;
            }
        }
    }

    //碰撞检测
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Prop")
        {
            Destroy(collider.gameObject);
            //显示对号一秒
            image.sprite = sp_right;
            isWaitTime = true;
        }
        isWaitTime = true;
    }
}
