using UnityEngine;
using System.Collections;

public class ClockHandler : MonoBehaviour
{
    private int CurrentRound = 0;
    private tk2dSprite sprite;

    private readonly string[] Sprites = new string[]
        {
            "clock0", "clock1", "clock2", "clock3", "clock4", "clock5", "clock6"
        };

    private Bounds bounds;
	void Start ()
	{
        // Position
	    sprite = GetComponent<tk2dSprite>();
	    bounds = sprite.GetBounds();

        transform.Translate(
                (-Camera.main.aspect*Camera.main.orthographicSize) + 0.1f,
                Camera.main.orthographicSize - 0.1f,
                0
            );

        // Begin tracking
	    CurrentRound = SixthsGameState.Round;
	}
	
	void Update () {
	    if (CurrentRound != SixthsGameState.Round)
	    {
	        CurrentRound = SixthsGameState.Round;
            if (CurrentRound < Sprites.Length)
            {
                sprite.SetSprite(Sprites[CurrentRound]);
            }
	    }
	}
}
