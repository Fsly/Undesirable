using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpProps : MonoBehaviour
{

    public Image image;
    public Sprite sp_right;
    public Sprite sp_wrong;
    public Sprite[] sp_need;

    public GameObject RightExplosion;
    public GameObject WrongExplosion;

    public List<int> needList;
    public int nowNeed;
    public List<Sprite> spList;

    public Slider ShowSlider;

    public float waitTime;

    public bool isWaitTime = false;



    // Start is called before the first frame update
    void Start()
    {
        needList.Clear();
        nowNeed = 0;
        for (int i = 0; i < 5; i++)
        {
            int r = Random.Range(1, 4);
            needList.Add(r);
            spList.Add(sp_need[r - 1]);
        }
        image.sprite = spList[nowNeed];
        //for (int i = 0; i < 5; i++) Debug.Log(needList[i]);

        ShowSlider.value = 0;
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
                waitTime = 0.5f;
                //显示道具
                image.sprite = spList[nowNeed];
            }
            if (nowNeed < 4) ShowSlider.value = 0.2f * nowNeed;
            else ShowSlider.value = 1;
        }
    }

    //碰撞检测
    private void OnTriggerEnter(Collider collider)
    {
        if ((collider.tag == "Prop" && needList[nowNeed] == 1)
            || (collider.tag == "Prop2" && needList[nowNeed] == 2)
            || (collider.tag == "Prop3" && needList[nowNeed] == 3))
        {
            Destroy(collider.gameObject);
            //显示对号一秒
            image.sprite = sp_right;
            if (nowNeed < 4) nowNeed++;
            GameManager._instance.score++;
            Instantiate(RightExplosion, collider.transform.position, collider.transform.rotation);
        }
        else
        {
            Destroy(collider.gameObject);
            //显示错号一秒
            image.sprite = sp_wrong;
            GameManager._instance.totalTime -= 5;
            Instantiate(WrongExplosion, collider.transform.position, collider.transform.rotation);
        }
        isWaitTime = true;
    }
}
