using UnityEngine;
using System.Collections;

public class TargetBalloon : MonoBehaviour
{
    public int PointValue = 0;
    public AudioSource Sfx;

	void OnMouseUpAsButton ()
	{
	    SixthsGameState.Score += PointValue;
	    if (Sfx != null)
	    {
	        Sfx.Play();
	    }
	    if (PointValue > 0)
        {
            SixthsGameState.CurrentGoals--;
        }
        if (SixthsGameState.Score < 0)
        {
            SixthsGameState.Score = 0;
        }

	    DestroyObject(this.gameObject);
	}
}
