using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    //SerializedFields
    [Header("Music Controls")]
    [SerializeField] AudioSource theMusic;
    [SerializeField] bool startPlaying;

    [Header("Object Usage")]
    public BeatScroller theBS;
    public static GameController instance;

    [Header("Score System")]
    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    [Header("Multiplier System")]
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    [Header("Canvas UI")]
    public Text scoreText;
    public Text multiplierText;

    [Header("Results Screen")]
    public float totalNotes, normalHits, goodHits, perfectHits, missedHits;
    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;
    string rankVal;
    // Start is called before the first frame update
    void Start()
    {
        currentMultiplier = 1;
        instance = this;
        scoreText.text = ("Score: " + "0");
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
                theBS.hasStarted = true;
                theMusic.Play();
            }
        }
        else
        {
            if (!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);
                normalsText.text = "" + normalHits;
                goodsText.text = "" + goodHits;
                perfectsText.text = "" + perfectHits;
                missesText.text = "" + missedHits;
                float totalHits = totalNotes - missedHits;
                float percentHit = (totalHits / totalNotes) * 100;

                percentHitText.text = percentHit.ToString("F1") + "%";

                if (percentHit < 50)
                {
                    rankVal = "F";
                }
                else if (percentHit > 60 && percentHit < 70)
                {
                    rankVal = "D";
                }
                else if (percentHit > 70 && percentHit < 80)
                {
                    rankVal = "C";
                }
                else if (percentHit > 80 && percentHit < 90)
                {
                    rankVal = "B";
                }
                else if (percentHit > 90 && percentHit < 99)
                {
                    rankVal = "A";
                }
                else
                {
                    rankVal = "S";
                }

                rankText.text = rankVal;
                finalScoreText.text = currentScore.ToString();
            }
        }
    }

    public void NoteHit()
    {
        //Debug.Log("Hit On Time");
        //Debug.Log(currentScore);
        multiplierTracker++;
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = ("Score: " + currentScore);
        multiplierText.text = ("Multiplier: x" + currentMultiplier);
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
        normalHits++;
    }


    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiplierText.text = ("Multiplier: x" + currentMultiplier);
        missedHits++;
    }
}
