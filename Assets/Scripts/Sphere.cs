using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sphere : MonoBehaviour {

    GameObject sphere;
    GameObject square;
    GameObject wave;
    GameObject animated;
    public static Animator animator;
    Vector3 StartPosition = new Vector3(500, 500, -510);
    Vector3 StartPosition_animated = new Vector3(502.5f, 502.5f, -510f);
    float sign = 1;

    // Use this for initialization
    void Start () {
        sphere = GameObject.Find("Sphere");
        square = GameObject.Find("Square");
        wave = GameObject.Find("Wave");
        animated = GameObject.Find("Animated");
        animator = gameObject.GetComponent<Animator>();
        animator.enabled = false;
        sphere.transform.position = new Vector3(500, 500, -510);
    }

    // Update is called once per frame
    void Update () {
		if(EventSystem.pause == false)
        {
            Check_Toggle();
        }
        else
        {
            sphere.transform.position = new Vector3(500, 500, -510);
        }
	}

    void Check_Toggle()
    {
        if(square.GetComponent<Toggle>().isOn == true)
        {
            Square_Translate();
        }
        else if(wave.GetComponent<Toggle>().isOn == true)
        {
            Wave_Translate();
        }
        else if(animated.GetComponent<Toggle>().isOn == true)
        {
            Animated_Translate();
        }
        else
        {
            EventSystem.pause = false;
        }
    }

    void Square_Translate()
    {
        StartCoroutine(Wait((float)(1/(2*EventSystem.freq))));
    }

    void Wave_Translate()
    {
        
            sphere.transform.position = StartPosition + new Vector3( 0.0f, (float)EventSystem.amp * Mathf.Sin((float)EventSystem.freq * Time.time), 0.0f);
        
    }

    void Animated_Translate()
    {
        animator.speed = ((float)(1 / (2 * EventSystem.freq)));
        animator.enabled = true;
        
    }

    IEnumerator Wait(float time)
    {
        transform.position = StartPosition + new Vector3(0.0f, sign * (float)EventSystem.amp, 0.0f);
        yield return new WaitForSeconds(time);
        sign = -1 * sign;
        StopAllCoroutines();

    }
}
