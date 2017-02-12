using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnter : MonoBehaviour
{

    public Sprite Red_Car,   // 红色小车 撞车后显示的图片
        Yellow_Car;



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car_1_Part" || collision.tag == "Car_2_Part"||
            collision.tag == "Car_3_Part")
        {
            Time.timeScale = 0;  // 游戏停止

            gameObject.GetComponent<SpriteRenderer>().sprite = Red_Car;

            GameObject.FindGameObjectWithTag(collision.transform.tag).
                GetComponent<SpriteRenderer>().sprite = Yellow_Car;
        }

    }
}
