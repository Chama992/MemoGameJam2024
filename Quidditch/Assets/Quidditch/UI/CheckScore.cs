using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CheckScore : MonoBehaviour
{
    
    public int player1BallScore;
    public int player2BallScore;
    public int player1GoldenBallScore;
    public int player2GoldenBallScore;
    public int player1totalscore;
    public int player2totalscore;
    public float gamingTime = 180;
    public float gamingTimeNow = 0;
    private Player player1Component;
    private Player player2Component;
    public Text player1Text;
    public Text player2Text;
    public Text countTime;
    public Text countScore;
    private float TextLivingTime;
    private GameObject play1;
    private GameObject play2;
    // Start is called before the first frame update
    void Start()
    {
        play1 = GameObject.FindGameObjectWithTag("Player1");
        play2 = GameObject.FindGameObjectWithTag("Player2");
        player1Component = play1.GetComponent<Player>();
        player2Component = play2.GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        TextLivingTime += Time.deltaTime; 
        gamingTimeNow += Time.deltaTime;
        player1BallScore = player1Component.ballscore;
        player2BallScore = player2Component.ballscore;
        player1GoldenBallScore = player1Component.goldenthievesscore;
        player2GoldenBallScore = player2Component.goldenthievesscore;
        player1totalscore = player1Component.score;
        player2totalscore = player2Component.score;
        countTime.text = $"计时：{(int)gamingTimeNow}s";
        countScore.text = $"得分：{player1totalscore}:{player2totalscore}";
        if (TextLivingTime > 1.5)
        {
            player1Text.text = $"您抽取到的扫帚是：{play1.GetComponent<buff1>().broomName}";
            player2Text.text = $"您抽取到的扫帚是：{play2.GetComponent<b2>().broomName}";
        }
        if ( TextLivingTime >4)
        {
            Destroy(player1Text);
            Destroy(player2Text);
        }
        //if (player1totalscore >= 10)
        //{
        //    //游戏结束场景 跳转玩家一胜利
        //}
        //else if(player2totalscore >= 10)
        //{
        //    //游戏结束场景 跳转玩家二胜利
        //}
        if (gamingTimeNow >= gamingTime)
        {
            if (player1totalscore > player2totalscore)
            {
                SceneManager.LoadScene("win"); //游戏场景结束 跳转玩家一胜利
            }
            else if (player1totalscore < player2totalscore)
            {
                SceneManager.LoadScene("win2"); //游戏结束场景 跳转玩家二胜利
            }
            else if (player1totalscore == player2totalscore)
            {
                SceneManager.LoadScene("draw");//游戏场景结束 跳转平局
            }
        }
    }
}
