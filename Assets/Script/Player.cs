using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// 触控摇杆
    /// </summary>
    public FixedJoystick joystick;
    
    /// <summary>
    ///  移动速度
    /// </summary>
    public float moveSpeed = 0.05f;
    
    /// <summary>
    /// 垂直和水平输入
    /// </summary>
    private float hInput , vInput;
    
    /// <summary>
    /// 分数
    /// </summary>
    private int socre = 0;
    
    /// <summary>
    /// 获胜标题
    /// </summary>
    public GameObject winText;
    
    /// <summary>
    /// 获胜分数
    /// </summary>
    public int winScore = 8;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // 获取摇杆的水平和垂直输入
        hInput = joystick.Horizontal * moveSpeed;
        vInput = joystick.Vertical * moveSpeed;
        
        // 移动
        transform.Translate(hInput, vInput, 0);
    }
    
    // 碰撞检测
    private void OnCollisionEnter2D(Collision2D other)
    {
        // 如果碰撞到的是胡萝卜
        if (other.gameObject.CompareTag("Carrot"))
        {
            // 销毁自身
            Destroy(other.gameObject);
            // 分数加一
            socre++;
            
            // 如果分数大于等于获胜分数
            if (socre > winScore)
            {
                // 显示获胜标题
                winText.SetActive(true);
            }

        }
    }
}
