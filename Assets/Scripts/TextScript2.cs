using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextScript2 : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;

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
    private string[] possibleItems = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    private string[] Answer = new string[5];

    private bool firstStop = false;
    private bool secondStop = false;
    private bool thirdStop = false;
    private bool fourthStop = false;
    private bool fifthStop = false;

    private int Difficulty;

    int item1 = 1;
    int item2 = 1;
    int item3 = 1;
    int item4 = 1;
    int item5 = 1;
    // Start is called before the first frame update
    void Start()
    {
        Restart.gameObject.SetActive(false);
        StopButton.gameObject.SetActive(false);
        Difficulty = Random.Range(1, 4);
        if (Difficulty == 1)
        {
            Answer[0] = "P";
            Answer[1] = "I";
            Answer[2] = "Z";
            Answer[3] = "Z";
            Answer[4] = "A";
            HintText.text = "The passcode is a baked pie of Italian origin usually topped with meat and cheese.";
        }
        if (Difficulty == 2)
        {
            Answer[0] = "C";
            Answer[1] = "R";
            Answer[2] = "O";
            Answer[3] = "W";
            Answer[4] = "N";
            HintText.text = "The passcode is a thing that only kings and queens wear on their head.";
        }
        if (Difficulty == 3)
        {
            Answer[0] = "M";
            Answer[1] = "O";
            Answer[2] = "V";
            Answer[3] = "I";
            Answer[4] = "E";
            HintText.text = "The passcode is something that you watch that is a long sequence of images displayed rapidly.";
        }
        item1 = Random.Range(0, 26);
        item2 = Random.Range(0, 26);
        item3 = Random.Range(0, 26);
        item4 = Random.Range(0, 26);
        item5 = Random.Range(0, 26);
        tries += SkillSystem.Instance.Level;
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
            item5++;
            if (!firstStop)
            {
                //int randItem = Random.Range(0, possibleItems.Length);
                if (item1 >= 26)
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
            if (!fifthStop)
            {
                //int randItem = Random.Range(0, possibleItems.Length);
                if (item5 >= 26)
                {
                    item5 = 0;
                }
                text5.text = possibleItems[item5];
            }
            Timer = 0;
        }
        if (Counting)
        {
            Timer += Time.deltaTime;
        }
    }
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

    public void OnFithLetter()
    {
        fifthStop = true;
        EndTime -= .5f;
    }

    public void TryAgain()
    {
        int randomPuzzle = Random.Range(0, 2);
        SkillSystem.Instance.Level++;
        if(randomPuzzle == 0)
        {
            SceneManager.LoadScene("Game");
        }
        else if (randomPuzzle == 1)
        {
            SceneManager.LoadScene("Game2");
        }
    }

    public void Stop()
    {
        gameObject.SetActive(false);
    }

    private void CompareAnswer()
    {
        if (Difficulty == 1)
        {
            if (text1.text == Answer[0] && text2.text == Answer[1] && text3.text == Answer[2] && text4.text == Answer[3] && text5.text == Answer[4]
                && firstStop && secondStop && thirdStop && fourthStop && fifthStop)
            {
                HintText.text = "That is correct! You have successfully hacked in.";
                Restart.gameObject.SetActive(true);
                StopButton.gameObject.SetActive(true);
                Counting = false;
            }
            if (firstStop && secondStop && thirdStop && fourthStop && fifthStop)
            {
                if (text1.text != Answer[0] || text2.text != Answer[1] || text3.text != Answer[2] || text4.text != Answer[3] || text5.text != Answer[4])
                {
                    HintText.text = "That is wrong! You have to try again. The password is a baked pie of Italian origin usually topped with meat and cheese.";
                    tries--;
                    firstStop = false;
                    secondStop = false;
                    thirdStop = false;
                    fourthStop = false;
                    fifthStop = false;
                    EndTime = 2.5f;
                    FindObjectOfType<ShakeBehaviour>().Shake();
                }
            }
        }
        if (Difficulty == 2)
        {
            if (text1.text == Answer[0] && text2.text == Answer[1] && text3.text == Answer[2] && text4.text == Answer[3] && text5.text == Answer[4]
                && firstStop && secondStop && thirdStop && fourthStop && fifthStop)
            {
                HintText.text = "That is correct! You have successfully hacked in.";
                Restart.gameObject.SetActive(true);
                StopButton.gameObject.SetActive(true);
                Counting = false;
            }
            if (firstStop && secondStop && thirdStop && fourthStop && fifthStop)
            {
                if (text1.text != Answer[0] || text2.text != Answer[1] || text3.text != Answer[2] || text4.text != Answer[3] || text5.text != Answer[4])
                {
                    HintText.text = "That is wrong! You have to try again. The password is something worn by kings and queens.";
                    tries--;
                    firstStop = false;
                    secondStop = false;
                    thirdStop = false;
                    fourthStop = false;
                    fifthStop = false;
                    EndTime = 2.5f;
                    FindObjectOfType<ShakeBehaviour>().Shake();
                }
            }
        }
        if (Difficulty == 3)
        {
            if (text1.text == Answer[0] && text2.text == Answer[1] && text3.text == Answer[2] && text4.text == Answer[3] && text5.text == Answer[4]
                && firstStop && secondStop && thirdStop && fourthStop && fifthStop)
            {
                HintText.text = "That is correct! You have successfully hacked in.";
                Restart.gameObject.SetActive(true);
                StopButton.gameObject.SetActive(true);
                Counting = false;
            }
            if (firstStop && secondStop && thirdStop && fourthStop && fifthStop)
            {
                if (text1.text != Answer[0] || text2.text != Answer[1] || text3.text != Answer[2] || text4.text != Answer[3] || text5.text != Answer[4])
                {
                    HintText.text = "That is wrong! You have to try again. The password is a sequence of images displayed rapidly.";
                    tries--;
                    firstStop = false;
                    secondStop = false;
                    thirdStop = false;
                    fourthStop = false;
                    fifthStop = false;
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

        if (seconds <= 0)
        {
            minutes--;
            seconds = 60;
        }
        if (Counting)
        {
            seconds -= Time.deltaTime;
        }

        if (tries == 0)
        {
            Counting = false;
            HintText.text = "You're out of tries, better luck next time!";
            Restart.gameObject.SetActive(true);
            StopButton.gameObject.SetActive(true);
            firstStop = true;
            secondStop = true;
            thirdStop = true;
            fourthStop = true;
            fifthStop = true;
        }
    }
}
