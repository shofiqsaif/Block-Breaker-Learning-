using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //config files
    [Range(0,1)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointPerBlockDistroyed = 83;
    //States
    [SerializeField] int currentScore;
    [SerializeField] TextMeshProUGUI score;

    // Start is called before the first frame update

    private void Awake()
    {
        int gameStateCount = FindObjectsOfType<GameSession>().Length;
        if(gameStateCount > 1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        currentScore = 0;
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

    public void DestroyYourself()
    {
        Destroy(gameObject);
    }
}
