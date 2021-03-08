using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    //config files
    [Range(0,1)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointPerBlockDistroyed = 83;
    //States
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        score.text = currentScore.ToString();
    }

    public void addToScore()
    {
        currentScore = currentScore + pointPerBlockDistroyed;
    }
}
