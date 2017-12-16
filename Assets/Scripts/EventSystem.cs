using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EventSystem : MonoBehaviour {

    public static double freq = 1;
    public static double amp = 1;

    public static bool pause = true;

	// Use this for initialization
	void Start () {
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        pause = false;
    }

    public void Pause()
    {
        pause = true;
        Sphere.animator.enabled = false;
    }

    public void Get_Frequency(string Frequency)
    {
        try
        {
            freq = Convert.ToDouble(Frequency);
        }
        catch (FormatException)
        {
            Console.WriteLine("Unable to convert '{0}' to a Double.", freq);
        }
        catch (OverflowException)
        {
            Console.WriteLine("'{0}' is outside the range of a Double.", freq);
        }
    }

    public void Get_Amplitude(string Amplitude)
    {
        try
        {
            amp = Convert.ToDouble(Amplitude);
        }
        catch (FormatException)
        {
            Console.WriteLine("Unable to convert '{0}' to a Double.", amp);
        }
        catch (OverflowException)
        {
            Console.WriteLine("'{0}' is outside the range of a Double.", amp);
        }
    }
}
