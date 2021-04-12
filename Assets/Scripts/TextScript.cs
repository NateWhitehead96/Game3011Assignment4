using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextScript : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;

    public Text HintText;
    public Text TimeRemaining;
    public Text TriesRemaining;
    public Text DifficultyText;

    public Button Restart;
    public Button StopButton;

    private float seconds = 0;
    private float minutes = 5;
    private int tries = 3;

    private float Timer = 0;
    private float EndTime = 2.5f;
    private bool Counting = true;
    private string[] possibleItems = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    private string[] Answer = new string[4];

    private bool firstStop = false;
    private bool secondStop = false;
    private bool thirdStop = false;
    private bool fourthStop = false;

    private int Difficulty;

    int item1 = 1;
    int item2 = 1;
    int item3 = 1;
    int item4 = 1;
    // Start is called before the first frame update
    void Start()
    {
        Restart.gameObject.SetActive(false);
        StopButton.gameObject.SetActive(false);
        Difficulty = Random.Range(1, 4);
        if (Difficulty == 1)
        {
            Answer[0] = "N";
            Answer[1] = "A";
            Answer[2] = "T";
            Answer[3] = "E";
            HintText.text = "The passcode is the creators name.";
        }
        if (Difficulty == 2)
        {
            Answer[0] = "S";
            Answer[1] = "I";
            Answer[2] = "Z";
            Answer[3] = "E";
            HintText.text = "The passcode is the physical dimensions, proportions, magnitude, or extent of an object.";
        }
        if (Difficulty == 3)
        {
            Answer[0] = "L";
            Answer[1] = "U";
            Answer[2] = "C";
            Answer[3] = "K";
            HintText.text = "The passcode is the minigame. The minigame is the passcode.";
        }
        item1 = Random.Range(0, 26);
        item2 = Random.Range(0, 26);
        item3 = Random.Range(0, 26);
        item4 = Random.Range(0, 26);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        CompareAnswer();
        UpdateTexts();
        if (Timer >= EndTime)
        {
            item1++;
            item2++;
            item3++;
            item4++;
            if (!firstStop)
            {
                //int randItem = Random.Range(0, possibleItems.Length);
                if(item1 >= 26)
                {
                    item1 = 0;
                }
                text1.text = possibleItems[item1];
            }
            if (!secondStop)
            {
                //int randItem = Random.Range(0, possibleItems.Length);
                if (item2 >= 26)
                {
                    item2 = 0;
                }
                text2.text = possibleItems[item2];
            }
            if (!thirdStop)
            {
                //int randItem = Random.Range(0, possibleItems.Length);
                if (item3 >= 26)
                {
                    item3 = 0;
                }
                text3.text = possibleItems[item3];
            }
            if (!fourthStop)
            {
                //int randItem = Random.Range(0, possibleItems.Length);
                if (item4 >= 26)
                {
                    item4 = 0;
                }
                text4.text = possibleItems[item4];
            }
            Timer = 0;
        }
        if(Counting)
        {
            Timer += Time.deltaTime;
        }
    }

    // button functions to stop the letters and quicken the letter's rotations

    public void OnFirstLetter()
    {
        firstStop = true;
        EndTime -= .5f;
    }
    public void OnSecondLetter()
    {
        secondStop = true;
        EndTime -= .5f;
    }
    public void OnThirdLetter()
    {
        thirdStop = true;
        EndTime -= .5f;
    }
    public void OnFourthLetter()
    {
        fourthStop = true;
        EndTime -= .5f;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void Stop()
    {
        gameObject.SetActive(false);
    }

    private void CompareAnswer()
    {
        if (Difficulty == 1)
        {
            if (text1.text == Answer[0] && text2.text == Answer[1] && text3.text == Answer[2] && text4.text == Answer[3]
                && firstStop && secondStop && thirdStop && fourthStop)
            {
                HintText.text = "That is correct! You have successfully hacked in.";
                Restart.gameObject.SetActive(true);
                StopButton.gameObject.SetActive(true);
                Counting = false;
            }
            if (firstStop && secondStop && thirdStop && fourthStop)
            {
                if (text1.text != Answer[0] || text2.text != Answer[1] || text3.text != Answer[2] || text4.text != Answer[3])
                {
                    HintText.text = "That is wrong! You have to try again. The password is the creators name.";
                    tries--;
                    firstStop = false;
                    secondStop = false;
                    thirdStop = false;
                    fourthStop = false;
                    EndTime = 2.5f;
                    FindObjectOfType<ShakeBehaviour>().Shake();
                }
            }
        }
        if (Difficulty == 2)
        {
            if (text1.text == Answer[0] && text2.text == Answer[1] && text3.text == Answer[2] && text4.text == Answer[3]
                && firstStop && secondStop && thirdStop && fourthStop)
            {
                HintText.text = "That is correct! You have successfully hacked in.";
                Restart.gameObject.SetActive(true);
                StopButton.gameObject.SetActive(true);
                Counting = false;
            }
            if (firstStop && secondStop && thirdStop && fourthStop)
            {
                if (text1.text != Answer[0] || text2.text != Answer[1] || text3.text != Answer[2] || text4.text != Answer[3])
                {
                    HintText.text = "That is wrong! You have to try again. The password is the physical dimensions of an object.";
                    tries--;
                    firstStop = false;
                    secondStop = false;
                    thirdStop = false;
                    fourthStop = false;
                    EndTime = 2.5f;
                    FindObjectOfType<ShakeBehaviour>().Shake();
                }
            }
        }
        if (Difficulty == 3)
        {
            if (text1.text == Answer[0] && text2.text == Answer[1] && text3.text == Answer[2] && text4.text == Answer[3]
                && firstStop && secondStop && thirdStop && fourthStop)
            {
                HintText.text = "That is correct! You have successfully hacked in.";
                Restart.gameObject.SetActive(true);
                StopButton.gameObject.SetActive(true);
                Counting = false;
            }
            if (firstStop && secondStop && thirdStop && fourthStop)
            {
                if (text1.text != Answer[0] || text2.text != Answer[1] || text3.text != Answer[2] || text4.text != Answer[3])
                {
                    HintText.text = "That is wrong! You have to try again. The password is the minigame.";
                    tries--;
                    firstStop = false;
                    secondStop = false;
                    thirdStop = false;
                    fourthStop = false;
                    EndTime = 2.5f;
                    FindObjectOfType<ShakeBehaviour>().Shake();
                }
            }
        }
    }

    private void UpdateTexts()
    {
        TriesRemaining.text = "Tries Left: " + tries.ToString();
        TimeRemaining.text = minutes.ToString() + ":" + seconds.ToString("#00");
        DifficultyText.text = "Difficulty: " + Difficulty.ToString();

        if(seconds <= 0)
        {
            minutes--;
            seconds = 60;
        }
        if(Counting)
        {
            seconds -= Time.deltaTime;
        }

        if(tries == 0)
        {
            Counting = false;
            HintText.text = "You're out of tries, better luck next time!";
            Restart.gameObject.SetActive(true);
            StopButton.gameObject.SetActive(true);
            firstStop = true;
            secondStop = true;
            thirdStop = true;
            fourthStop = true;
        }
    }
}
