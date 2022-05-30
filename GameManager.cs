using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    
    public bool startPlaying;

    public BeatScroller theBs;

    public static GameManager instance;

    public int currentScore;
    //public int scorePerNote = 75;
    public int scorePerGoodNote = 100;
    public int scorePerPerfectNote = 100;

    public Text scoreText;
    public Text mutiText;
    public Text comboText;

    public int currentMuti;
    public int mutiplierTracker;
    public int[] mutiplierThresholds;

    public float totalNotes;
   // public float normalHit;
    public float goodHit;
    public float perfectHit;
    public float missHit;

    public int comboCount;
    public int highestCombo = 0;

    public GameObject resultsScreen;
    public GameObject faildScreen;
    //public Text normalsText;
    public Text goodsText, perfectTexts, missedText, finalScoreText , comboHighText;

    public int hp;
    public Text hpText;

    public bool checkHit = false;
    public bool checkMiss = false;


    void Start()
    {
        instance = this;
        scoreText.text = "0";
        currentMuti = 1;

        hp = 1000;
        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBs.hasStarted = true;

                theMusic.Play();
              

            }
        }
        else
        {
            if (!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);

                //normalsText.text = normalHit.ToString();
                goodsText.text = goodHit.ToString();
                perfectTexts.text = perfectHit.ToString();
                missedText.text = missHit.ToString();
                comboHighText.text = highestCombo.ToString();

                float totalHit = goodHit + perfectHit;
                float percentHit = (totalHit / totalNotes) * 100;

                

                finalScoreText.text = currentScore.ToString();

            }
        }

        ComboCount();
        HpCount();


    }

    public void HpCount()
    {
        hpText.text = hp.ToString();
        if (hp <= 0)
        {
            faildScreen.SetActive(true);
            startPlaying = false;
            theBs.hasStarted = false;
            theMusic.Stop();
        }
    }
    public void ComboCount()
    {
        if (comboCount > highestCombo)
        {
            highestCombo = comboCount;
        }

        if (comboCount == 0)
        {
            comboText.text = (" ");
        }
        else
        {
            comboText.text = comboCount.ToString();
        }

       

    }

    public void NoteHit()
    {
        Debug.Log("Hit on Time");

        if(currentMuti - 1 < mutiplierThresholds.Length)
        {
            mutiplierTracker++;

            if (mutiplierThresholds[currentMuti - 1] <= mutiplierTracker)
            {
                mutiplierTracker = 0;
                currentMuti++;
            }

            //currentScore += scorePerNote * currentMuti;
            scoreText.text = " " + currentScore;
        }

        mutiText.text = " x " + currentMuti;
        
    }


 /*   public void NormalHit()
    {
        currentScore += scorePerNote * currentMuti;
        NoteHit();

        normalHit++;
        comboCount++;
    }
 */
    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMuti;
        NoteHit();

        goodHit++;
        comboCount++;
        
        checkHit = true;

    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMuti;
        NoteHit();

        perfectHit++;
        comboCount++;

        checkHit = true;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        currentMuti = 1;
        mutiplierTracker = 0;

        mutiText.text = " x " + currentMuti;

        missHit++;
        comboCount = 0;

        hp -= 50;
        hpText.text = hp.ToString();

        checkMiss = true;
    }

   
}
