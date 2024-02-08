using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject theBall;
    private int leftScore = 0;
    private int rightScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BallScored()
    {
        Debug.Log("A ball has been scored!");

        if (theBall.transform.position.y < 0)
        {
            Debug.Log("The left player scored a point!");
            leftScore++;
            theBall.GetComponent<DemoBall>().ResetBall(0.0);
        }
        else
        {
            Debug.Log("The right player scored a point!");
            rightScore++;
            theBall.GetComponent<DemoBall>().ResetBall(1.0);
        }

        standardScorePrint();

    }

    void standardScorePrint()
    {
        Debug.Log("The score is " + leftScore + " - " + rightScore);

        if (leftScore > rightScore)
        {
            Debug.Log("The left player is currently in the lead!");
        }
        else if (leftScore < rightScore)
        {
            Debug.Log("The right player is currently in the lead!");
        }
        else
        {
            Debug.Log("It's anyone's game!!!");
        }

        if (leftScore == 11 || rightScore == 11)
        {
            ResetGame();
        }

    }

    private void ResetGame()
    {
        if (leftScore == 11)
        {
            Debug.Log("Game Over, Left Paddle Wins!");
        }

        if (rightScore == 11)
        {
            Debug.Log("Game Over, Right Paddle Wins!");
        }

        leftScore = 0;
        rightScore = 0;
    }


}
