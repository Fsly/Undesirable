﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player02 : MonoBehaviour
{
    private Animator anim;
    public Transform parent;

    public float speed;
    public float deadTime;

    public bool isDead = false;

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
        if (!isDead)
        {
            if (this.transform.position.y < -1)
            {
                //复位
                isDead = true;
            }

            Player02Control();

        }
        else
        {
            deadTime -= Time.deltaTime;
        }
        if (deadTime <= 0)
        {
            isDead = false;
            deadTime = 2f;
            this.transform.position = new Vector3(parent.transform.position.x + 1f, parent.transform.position.y + 1f, parent.transform.position.z + 1f);
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public void Player02Control()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            SetState(up);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            SetState(down);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            SetState(left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            SetState(right);
        }
        else
        {
            anim.SetFloat("Run", 0);
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
        transform.Translate(transformValue, Space.World);
        oldState = State;
        State = currState;
    }
}
