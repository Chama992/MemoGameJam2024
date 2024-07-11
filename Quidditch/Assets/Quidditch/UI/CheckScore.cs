using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CheckScore : MonoBehaviour
{
    public int player1BallScore;
    public int player2BallScore;
    public int player1GoldenBallScore;
    public int player2GoldenBallScore;
    public int player1totalscore;
    public int player2totalscore;
    private Player player1Component;
    private Player player2Component;
    // Start is called before the first frame update
    void Start()
    {
        GameObject play1 = GameObject.FindGameObjectWithTag("Player1");
        GameObject Play2 = GameObject.FindGameObjectWithTag("Player2");
        player1Component = play1.GetComponent<Player>();
        player2Component = Play2.GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        player1BallScore = player1Component.ballscore;
        player2BallScore = player2Component.ballscore;
        player1GoldenBallScore = player1Component.goldenthievesscore;
        player2GoldenBallScore = player2Component.goldenthievesscore;
        player1totalscore = player1Component.score;
        player2totalscore = player2Component.score;

    }
}
