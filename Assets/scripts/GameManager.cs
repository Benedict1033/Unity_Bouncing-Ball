using System. Collections;
using System. Collections. Generic;
using UnityEngine;
using UnityEngine. EventSystems;
using UnityEngine. SceneManagement;
using UnityEngine. UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;
    public static bool isGameStarted;
    public static bool mute = false;

    public GameObject GameOverPanel;
    public GameObject WinPanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;

    public static int currentLevelIndex;
    public Slider GameProgress;
    public Text currentLevel;
    public Text nextLevel;
    public Text Score;
    public Text highScore;

    public static int numOfPassedRing;
    public static int score=0;


    private void Awake ( )
    {
        currentLevelIndex=PlayerPrefs. GetInt ( "CurrentLevelIndex", 1 );
    }

    private void Start ( )
    {
        Time. timeScale=1;
        numOfPassedRing=0;
        highScore. text="Best Score\n"+PlayerPrefs. GetInt ( "HighScore", 0 );
        isGameStarted=gameOver=levelCompleted=false;
    }

    private void Update ( )
    {
        //if ( Input. GetMouseButtonDown ( 1 ) )
        //{
        //    PlayerPrefs. DeleteAll ( );
        //    SceneManager. LoadScene ( "Game" );

        //}


        //Update UI
        currentLevel. text=currentLevelIndex. ToString ( );
        nextLevel. text=( currentLevelIndex+1 ). ToString ( );

        int progress = numOfPassedRing*100/FindObjectOfType<HelixManager>().numberOfRings;
        GameProgress. value=progress;

        Score. text=score. ToString ( );

        //start level
        if ( Input. touchCount>0&&Input. GetTouch ( 0 ). phase==TouchPhase. Began&&!isGameStarted )
        {
            if ( EventSystem. current. IsPointerOverGameObject ( Input. GetTouch ( 0 ). fingerId ) )
            {
                return;
            }

            isGameStarted=true;
            gamePlayPanel. SetActive ( true );
            startMenuPanel. SetActive ( false );
        }


        //pc
        if ( Input.GetMouseButtonDown ( 0 )&&!isGameStarted )
        {
            if ( EventSystem. current. IsPointerOverGameObject ( ) )
            {
                return;
            }

            isGameStarted=true;
            gamePlayPanel. SetActive ( true );
            startMenuPanel. SetActive ( false );
        }



        //Game Over
        if ( gameOver )
        {
            Time. timeScale=0;
            GameOverPanel. SetActive ( true );

            if ( Input. GetMouseButtonDown ( 0 ) )
            {
                if ( score>PlayerPrefs. GetInt ( "HighScore", 0 ) )
                {
                    PlayerPrefs. SetInt ( "HighScore", score );
                }
                score=0;
                SceneManager. LoadScene ( "Game" );
            }
        }

        //Complete level
        if ( levelCompleted )
        {
            WinPanel. SetActive ( true );

            if ( Input. GetMouseButtonDown ( 0 ) )
            {
                if ( score>PlayerPrefs. GetInt ( "HighScore", 0 ) )
                {
                    PlayerPrefs. SetInt ( "HighScore", score );
                }

                PlayerPrefs. SetInt ( "CurrentLevelIndex", currentLevelIndex+1 );
                SceneManager. LoadScene ( "Game" );
            }
        }
    }
}
