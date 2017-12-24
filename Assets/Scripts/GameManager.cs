using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Transform TargetBalloon;
    public Transform PenaltyBalloon;
    public tk2dTiledSprite Cover;

    public AudioSource[] PopSfx;

    public Transform GameOverScreen;
    public MeshRenderer TimeUpMessage;
    public MeshRenderer CompleteMessage;

    public tk2dTextMesh ScoreText;
    public tk2dTextMesh HighScoreText;

    public AudioSource TransitionIn;
    public AudioSource TransitionOut;

    public tk2dSprite Cursor;

    private float HiddenZ = -20;
    private float VisibleZ = -9.5f;

    private float MaxY;
    private float MaxX;

    void Start()
    {
        StartNewGame();
        PrepareRound();
    }

    private Vector3 pos;
    private Transform balloon;
    private float z = 0;
    void PrepareRound()
    {
        MaxY = Camera.main.orthographicSize;
        MaxX = Camera.main.aspect * MaxY;

        // Clear all existing balloons
        var children = GetComponentsInChildren<Transform>();
        foreach (Transform c in children)
        {
            if (c != transform)
            {
                DestroyObject(c.gameObject);
            }
        }

        if (SixthsGameState.PlayRound)
        {
            // Create goal balloons
            z = 0;
            for (int i = 0; i < SixthsGameState.CurrentGoals; i++)
            {
                CreateRandomBalloon(TargetBalloon);
            }

            // Create penalty balloons
            for (int i = 0; i < SixthsGameState.Noise; i++)
            {
                CreateRandomBalloon(PenaltyBalloon);
            }

            Cover.GetComponent<Renderer>().enabled = false;
            TransitionOut.Play();
        }
        else
        {
            Cover.GetComponent<Renderer>().enabled = true;
            TransitionIn.Play();
        }

        SixthsGameState.Timer = 10;
    }

    void CreateRandomBalloon(Transform prefab)
    {
        balloon = (Transform) Instantiate(prefab);
        balloon.gameObject.GetComponent<TargetBalloon>().Sfx = PopSfx[Random.Range(0, PopSfx.Length - 1)];
        pos.x = Random.Range(-MaxX, MaxX);
        pos.y = Random.Range(-MaxY, MaxY);
        pos.z = z;
        z += 0.02f;
        balloon.parent = transform;
        balloon.Translate(pos);
    }

	void Update ()
	{
	    if (SixthsGameState.GameRunning)
	    {
	        SixthsGameState.Timer -= Time.deltaTime;

	        // Time rounds
	        if (SixthsGameState.Timer < 0)
	        {
	            SixthsGameState.PlayRound = !SixthsGameState.PlayRound;
	            SixthsGameState.Round++;
	            Debug.Log(SixthsGameState.Round);
	            PrepareRound();
	        }

	        // Game over states
	        if (SixthsGameState.Round == 6)
	        {
                TimeUpMessage.enabled = true;
                CompleteMessage.enabled = false;
                DoGameOver();
	        }
	        else if (SixthsGameState.CurrentGoals == 0)
	        {
	            TimeUpMessage.enabled = false;
	            CompleteMessage.enabled = true;
                DoGameOver();
	        }
	    }
	}

    private int highScore;
    private const string HighScorePrefsKey = "HighScore";
    void DoGameOver()
    {
        TransitionIn.Play();
        Cover.GetComponent<Renderer>().enabled = true;
        Cursor.GetComponent<Renderer>().enabled = false;
        GameOverScreen.Translate(0, 0, VisibleZ - GameOverScreen.position.z);

        ScoreText.text = SixthsGameState.Score.ToString();
        ScoreText.Commit();

        // Handle high score
        highScore = PlayerPrefs.GetInt(HighScorePrefsKey, 0);
        if (SixthsGameState.Score > highScore)
        {
            highScore = SixthsGameState.Score;
            PlayerPrefs.SetInt(HighScorePrefsKey, highScore);
            PlayerPrefs.Save();
        }
        HighScoreText.text = highScore.ToString();
        HighScoreText.Commit();

        SixthsGameState.GameRunning = false;
    }

    public void StartNewGame()
    {
        TransitionOut.Play();
        Cover.GetComponent<Renderer>().enabled = false;
        Cursor.GetComponent<Renderer>().enabled = true;
        GameOverScreen.Translate(0, 0, HiddenZ - GameOverScreen.position.z);

        SixthsGameState.GameRunning = true;
        SixthsGameState.Score = 0;
        SixthsGameState.CurrentGoals = SixthsGameState.Goal;
        SixthsGameState.PlayRound = false;
        SixthsGameState.Round = 0;
        PrepareRound();
    }
}
