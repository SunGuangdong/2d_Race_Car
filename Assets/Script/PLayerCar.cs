using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PLayerCar : MonoBehaviour {

    [SerializeField]
    private GameObject Player1,  // 红色小车1
        Player2;

    [SerializeField]
    private GameObject Car1, // 黄色小车
        Car2,
        Car3;

    private DOTweenPath DoPlayerPath,
        DoCar1Path,
        DoCar2Path,
        DoCar3Path;

    private bool AddSpeed = true;

    private bool IsAddSpeed;  // 判断小车是否已经脱离车队

    private float Timer;        // 纪录时间

    private void Awake()
    {
        DoPlayerPath = GetComponent<DOTweenPath>();

        DoCar1Path = Car1.GetComponent<DOTweenPath>();
        DoCar2Path = Car2.GetComponent<DOTweenPath>();
        DoCar3Path = Car3.GetComponent<DOTweenPath>();
    }


    // Use this for initialization
    void Start() {
        DoPlayerPath.GetTween().timeScale += 0.02f;  // 是动画速度变快

        DoCar1Path.GetTween().timeScale += 0.02f;
        DoCar2Path.GetTween().timeScale += 0.02f;
        DoCar3Path.GetTween().timeScale += 0.02f;

        // 开始动画
        DoCar1Path.DOPlayForward();
        DoCar2Path.DOPlayForward();
        DoCar3Path.DOPlayForward();
        DoPlayerPath.DOPlayForward();
    }

    // Update is called once per frame
    void Update() {
        // 红色小车每增加一次速度， 速度上线为1.2f;
        if (AddScore.Score % 2 == 0 && AddScore.Score != 0 && AddSpeed &&
            DoPlayerPath.GetTween().timeScale <= 1.2f)
        {
            DoPlayerPath.GetTween().timeScale += 0.025f; // 速度增加。 这个值是测试下来的值
            DoCar1Path.GetTween().timeScale += 0.025f;
            DoCar2Path.GetTween().timeScale += 0.025f;
            DoCar3Path.GetTween().timeScale += 0.025f;

            AddSpeed = false;
        }
        else if (AddScore.Score % 2 == 1)
        {
            // 当分数为 3 6 9 11.。。的时候还原
            AddSpeed = true;
        }

        // 第7和 20圈 小车加速 脱离车队
        if (AddScore.Score == 6 || AddScore.Score == 19)
        {
            IsAddSpeed = true;
        }
        if ((AddScore.Score == 7 || AddScore.Score == 20) && IsAddSpeed)
        {
            IsAddSpeed = false;
            if (AddScore.Score == 7)
            {
                DoCar3Path.GetTween().timeScale += 0.03f; // 这个值是测试下来的值
            }
            else
            {
                DoCar1Path.GetTween().timeScale = 0.92f; // 这个值是测试下来的值
            }

            Timer = Time.time; // 纪录当前时间
        }
        if (Timer != 0 && (Time.time - Timer) > 3)
        {
            Timer = 0;  // 将timer 设置为0，这样只有！=0 的时候才会进入判断
            DoCar3Path.GetTween().timeScale = DoPlayerPath.GetTween().timeScale;
            DoCar1Path.GetTween().timeScale = DoPlayerPath.GetTween().timeScale;
        }

        // 小车 变道
        if (Input.GetButtonDown("Fire1") && Time.timeScale != 0) // 因为当游戏结束时 我们是使TimeScale = 0来暂停游戏的
        {
            if (Player1.activeSelf)
            {
                Player1.SetActive(false);
                Player2.SetActive(true);
            }
            else
            {
                Player1.SetActive(true);
                Player2.SetActive(false);
            }
        }
	}
}
