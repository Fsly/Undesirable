﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01 : MonoBehaviour
{
    private Animator anim;

    public float speed;

    private int State;
    private int oldState;
    private int up = 0;
    private int right = 1;
    private int down = 2;
    private int left = 3;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y<-10)
        {
            //复位
        }

        Player01Control();
        
    }

    public void Player01Control()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
        }

        AnimatorStateInfo animatorInfo;
        animatorInfo = anim.GetCurrentAnimatorStateInfo(0);
        string name = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if (name != "FreeVoxelGirl-lose")//normalizedTime: 范围0 -- 1,  0是动作开始，1是动作结束
        {
            if (Input.GetKey(KeyCode.W))
            {
                SetState(up);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                SetState(down);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                SetState(left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                SetState(right);
            }
            else
            {
                anim.SetFloat("Run", 0);
            }
        }
    }


    public void SetState(int currState)
    {
        Vector3 transformValue = new Vector3();
        int rotateValue = (currState - State) * 90;
        //动画
        anim.SetFloat("Run", 1);
        switch (currState)
        {
            case 0://角色状态向前时，角色不断向前缓慢移动
                transformValue = Vector3.forward * Time.deltaTime * speed;
                break;
            case 1://角色状态向右时。角色不断向右缓慢移动
                transformValue = Vector3.right * Time.deltaTime * speed;
                break;
            case 2://角色状态向后时。角色不断向后缓慢移动
                transformValue = Vector3.back * Time.deltaTime * speed;
                break;
            case 3://角色状态向左时，角色不断向左缓慢移动
                transformValue = Vector3.left * Time.deltaTime * speed;
                break;
        }
        transform.Rotate(Vector3.up, rotateValue);
        transform.Translate(transformValue,Space.World);
        oldState = State;
        State = currState;
    }
}
