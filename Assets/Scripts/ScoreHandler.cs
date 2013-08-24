using UnityEngine;
using System.Collections;

public class ScoreHandler : MonoBehaviour
{
    private int CurrentScore = 0;
    private tk2dTextMesh mesh;

	void Start ()
	{
        // Position
	    mesh = GetComponent<tk2dTextMesh>();

        transform.Translate(
            (Camera.main.aspect * Camera.main.orthographicSize) - 0.1f,
            Camera.main.orthographicSize - 0.1f,
            0
            );

        // Begin tracking
	    CurrentScore = SixthsGameState.Score;
	}
	
	// Update is called once per frame
	void Update () {
	    if (CurrentScore != SixthsGameState.Score)
	    {
            mesh.text = SixthsGameState.Score.ToString();
            mesh.Commit();
	        CurrentScore = SixthsGameState.Score;
	    }
	}
}
