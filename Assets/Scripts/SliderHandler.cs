using UnityEngine;
using System.Collections;

public class SliderHandler : MonoBehaviour
{

    public int Minimum;
    public int Maximum;
    public int Snap;

    public int Value;

    private tk2dSprite track;

    private float length;
    private float minX;
    private float maxX;
    private float snap;

    public void SetValue(int value)
    {
        pos = transform.position;
        pos.x = (((value - Minimum) / (float)(Maximum - Minimum)) * length) + minX;
        if (pos.x > maxX)
        {
            pos.x = maxX;
        }
        else if (pos.x < minX)
        {
            pos.x = minX;
        }
        transform.position = pos;
        Value = value;
    }

	// Use this for initialization
	void Start ()
	{
        // Get pieces
	    track = transform.parent.GetChild(1).gameObject.GetComponent<tk2dSprite>();

        // Calculate useful values
	    minX = track.GetComponent<Renderer>().bounds.min.x;
	    maxX = track.GetComponent<Renderer>().bounds.max.x;
	    length = maxX - minX;
	    snap = length / ((Maximum - Minimum) / Snap);

        // Set initial value
        SetValue(Value);
	}

    private Vector3 mouse;
    private Vector3 pos;
	void OnMouseDrag()
	{
	    mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

	    pos = transform.position;
	    pos.x = (snap * Mathf.Round((mouse.x - minX) / snap)) + minX;
        if (pos.x > maxX)
        {
            pos.x = maxX;
        }
        else if (pos.x < minX)
        {
            pos.x = minX;
        }

        Value = Minimum + Mathf.RoundToInt(((pos.x - minX) / length) * (Maximum - Minimum));

	    transform.position = pos;
	}
}
