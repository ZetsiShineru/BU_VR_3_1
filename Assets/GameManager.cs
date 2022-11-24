using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    public int score = 0;
    [SerializeField] private Text scoreText;

    public int targetScore = 10;
    public GameObject exitArea;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        scoreText.text = $"Whey: " + score;
    }

    public void AddScore()
    {
        score = score + 1;
        scoreText.text = $"Whey: " + score;
        if(score >= targetScore)
        {
            exitArea.SetActive(true);
        }
    }

    public void Victory()
    {
        //Do something
    }
}
