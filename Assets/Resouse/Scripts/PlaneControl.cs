using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{
    public int DestoryMinNum;
    public int DestoryMaxNum;
    public List<GameObject> planeList;
    public List<int> changeList;

    public Material nonalMat;
    public Material warningMat;

    public float startTime;
    public float destoryTime;
    public float waitTime;

    public bool isStartTime = true;
    public bool isWaitTime;
    public bool isDestoryTime;

    // Start is called before the first frame update
    void Start()
    {
        StartTimeDoSomething();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(isStartTime)
        {
            startTime -= Time.deltaTime;
            if(startTime<=0)
            {
                isStartTime = false;
                isWaitTime = true;
                waitTime = 2f;
                //变色
                ChangeColor();
            }
        }
        if(isWaitTime)
        {
            waitTime -= Time.deltaTime;
            if(waitTime<=0)
            {
                isWaitTime = false;
                isDestoryTime = true;
                destoryTime = 5f;
                //破坏
                DestoryPlane();
            }
        }
        if(isDestoryTime)
        {
            destoryTime -= Time.deltaTime;
            if(destoryTime<=0)
            {
                isDestoryTime = false;
                isStartTime = true;
                startTime = 5f;
                //恢复
                ResetPlane();
                ResetPlaneColor();
                StartTimeDoSomething();
            }
        }

    }

    public void StartTimeDoSomething()
    {
        //随机位置
        changeList.Clear();
        int destoryNum = Random.Range(DestoryMinNum, DestoryMaxNum);
        for (int i = 0; i < destoryNum; i++)
        {
            int index = Random.Range(0, planeList.Count - 1);
            while (changeList.Exists(s => s.Equals(index)))
            {
                //存在
                index = Random.Range(0, planeList.Count - 1);
            }
            changeList.Add(index);
        }
    }

    public void ChangeColor()
    {
        for (int i = 0; i < changeList.Count; i++)
        {
            planeList[changeList[i]].GetComponent<MeshRenderer>().materials = new Material[2] { nonalMat, warningMat };
        }
    }

    public void DestoryPlane()
    {
        for (int i = 0; i < changeList.Count; i++)
        {
            planeList[changeList[i]].SetActive(false);
        }
    }

    public void ResetPlane()
    {
        for (int i = 0; i < changeList.Count; i++)
        {
            planeList[changeList[i]].SetActive(true);
        }
    }

    public void ResetPlaneColor()
    {
        for (int i = 0; i < changeList.Count; i++)
        {
            planeList[changeList[i]].GetComponent<MeshRenderer>().materials = new Material[2] { nonalMat, nonalMat };
        }
    }
}
