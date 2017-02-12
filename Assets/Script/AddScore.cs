using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{

    public static int Score;   // 记录分数

    private int MaxScore;    // 最高分

    // Use this for initialization
    void Start()
    {
        MaxScore = PlayerPrefs.GetInt("MaxScore", MaxScore);

        Score = 0;

    }

    void Update()
    {
        PlayerPrefs.SetInt("MaxScore", MaxScore);

        if (Score > PlayerPrefs.GetInt("MaxScore", MaxScore))
        {
            MaxScore = Score;
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCar")
        {
            Score++;
            Debug.Log(Score);
        }
    }
}
