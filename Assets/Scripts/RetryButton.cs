using UnityEngine;
using System.Collections;

public class RetryButton : MonoBehaviour
{
    public GameManager GameManager;
    public AudioSource Sfx;

    void OnMouseUpAsButton()
    {
        Sfx.Play();
        GameManager.StartNewGame();
    }
}
