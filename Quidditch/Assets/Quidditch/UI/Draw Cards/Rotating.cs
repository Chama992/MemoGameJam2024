using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    [Tooltip("轮盘节点")]
    public Transform Roulette;
    [Tooltip("轮盘旋转的圈数")]
    public int RotateNumber = 4;
    //[Tooltip("轮盘需要旋转的度数")]
    private float degrees = 0;
    [Tooltip("轮盘旋转初速度")]
    public int RotateSpeed = 500;
    //[Tooltip("当前轮盘旋转速度")]
    private float curRotateSpeed = 0;
    [Tooltip("减速度")]
    public float deceleration = 3;
    [Tooltip("最低速度")]
    public float minSpeed = 50;
    [Tooltip("轮盘剩余旋转多少时开始减速")]
    public float surRotate = 720;
    [Tooltip("轮盘中物体的数量")]
    public int All = 6;
    [Tooltip("旋转停止的位置")]
    public int selectedIndex = 1;
    [Tooltip("精准角度")]
    public Boolean enblePrecise = false;
    //开启轮盘转动
    private Boolean enbleLunpan = false;

    private void Start()
    {
        //每秒的帧率改为60（不是必要）
        Application.targetFrameRate = 60;
    }

    private void Update()
    {

        if (this.enbleLunpan)
        {
            //存储每帧需要旋转的角度
            float curRotate = 0;

            if (this.degrees > 0)
            {
                //计算此帧需要旋转的角度
                curRotate = Time.deltaTime * this.curRotateSpeed;

                //精准到指定角度
                if (this.enblePrecise && curRotate > this.degrees)
                {
                    if (this.curRotateSpeed >= this.minSpeed)
                    {
                        //速度减半
                        this.curRotateSpeed = this.minSpeed / 2;
                        curRotate = Time.deltaTime * this.curRotateSpeed;
                        if (curRotate > this.degrees)
                        {
                            curRotate = this.degrees;
                        }
                    }
                    else
                    {
                        curRotate = this.degrees;
                    }

                }

                //减速
                if (this.curRotateSpeed > this.minSpeed && this.degrees < this.surRotate)
                {
                    this.curRotateSpeed -= deceleration;
                }

                //开始旋转
                this.Roulette.Rotate(Vector3.back * curRotate);
                this.degrees -= curRotate;

                if (this.degrees <= 0)
                {
                    this.enbleLunpan = false;
                }

            }
        }



    }

    /// <summary>
    /// 开始转动
    /// </summary>
    public void StartRoulette()
    {
        this.curRotateSpeed = this.RotateSpeed;

        //计算轮盘总需要旋转的角度
        this.degrees = this.RotateNumber * 360 - ((this.selectedIndex - 1) * 360) / this.All - (360 - this.Roulette.eulerAngles.z);
        this.enbleLunpan = true;
    }
}
