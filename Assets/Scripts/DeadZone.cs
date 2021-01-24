using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadZone : MonoBehaviour
{
    public Text PlayerText;
    public Text OtherText;
    public BallBehaviour ballBehaviour;
    public SceneChanger sceneChanger;
    public AudioSource PointAudio;

    public static int PlayerScore = 0;
    int OtherScore = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "ZoneWin")
        {
            if (PointAudio != null)
                PointAudio.Play();

            PlayerScore++;
            updateScore(PlayerText, PlayerScore);
        }

        else if (gameObject.tag == "ZoneLose")
        {
            OtherScore++;
            updateScore(OtherText, OtherScore);
        }

        ballBehaviour.gameStarted = false;
        checkGameover();
    }
    void updateScore(Text label, int score)
    {
        label.text = score.ToString();
    }
    void checkGameover()
    {
        if (PlayerScore >= 3) sceneChanger.ChangeScreen("Win");
        if (OtherScore >= 3) sceneChanger.ChangeScreen("Lose");

    }
}
