using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private GenRoad _genRoad;
    private GameObject _ball;
    private GameObject _tapStart;
    private GameObject _scoreFinal;
    private GameObject _scoreText;
    public bool _startedGame = false;
    int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        _ball = GameObject.Find("Ball");
        _tapStart = GameObject.Find("TapToStart");
        _genRoad = GameObject.Find("RoadTile").GetComponent<GenRoad>();
        _scoreFinal = GameObject.Find("Canvas").transform.Find("ScoreFinal").gameObject;
        _scoreText = GameObject.Find("Canvas").transform.Find("ScoreName").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)&&!_startedGame)
        {
            startGame();            
        }
    }

    public void addScore()
    {
        _score++;
        _scoreText.GetComponent<Text>().text = "Ваш счет: " + _score;
    }

    public void startGame()
    {
        for (int i = 0; i < 40; i++)
        {
            _genRoad.GenerationRoad();
        }
        _startedGame = true;
        _tapStart.SetActive(false);
        _scoreText.SetActive(true);
    }

    public void gameOver()
    {
        _scoreFinal.GetComponent<Text>().text +=_score;
        _scoreText.SetActive(false);
        _scoreFinal.SetActive(true);        
        _startedGame = false;
        GameObject.Find("Canvas").transform.Find("Button").gameObject.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
