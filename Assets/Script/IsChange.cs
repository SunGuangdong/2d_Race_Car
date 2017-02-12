using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsChange : MonoBehaviour {

    private int Ran;  // 随机数

    [SerializeField]
    GameObject Car_1_1,
        Car_1_2,

        Car_2_1,
        Car_2_2,

        Car_3_1,
        Car_3_2;


	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car3")   // 因为 Car3 在最右边 最先碰到碰撞体
        {
            Ran = Random.Range(0, 2);

            int IsChange = Ran;
            ChageCar(Car_3_1, Car_3_2, IsChange);
        }

        if (collision.tag == "Car2")
        {
            int IsChange = Ran;
            if (AddScore.Score >= 7)
            {
                Ran = Random.Range(0, 2);
                IsChange = Ran;
            }
            
            ChageCar(Car_2_1, Car_2_2, IsChange);
        }

        if (collision.tag == "Car1")
        {
            int IsChange = Ran;
            if (AddScore.Score >= 20)
            {
                Ran = Random.Range(0, 2);
                IsChange = Ran;
            }

            ChageCar(Car_1_1, Car_1_2, IsChange);
        }
    }

    void ChageCar(GameObject Car1, GameObject Car2, int IsChange)
    {
        if (IsChange == 1)
        {
            if (Car1.activeSelf)
            {
                Car1.SetActive(false);
                Car2.SetActive(true);
            }
            else
            {
                Car1.SetActive(true);
                Car2.SetActive(false);
            }
        }
    }
}
