using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator controls;
    public Animator planets;

    public void triggerControls()
    {
        if (controls.GetComponent<RectTransform>().anchoredPosition.x == -120f)
        {
            controls.SetTrigger("In");
        }else if (controls.GetComponent<RectTransform>().anchoredPosition.x == 120f)
        {
            controls.SetTrigger("Out");
        }
    }
    public void triggerPlanets()
    {
        if (planets.GetComponent<RectTransform>().anchoredPosition.x == 145f)
        {
            planets.SetTrigger("In");
        }
        else if (planets.GetComponent<RectTransform>().anchoredPosition.x == -145f)
        {
            planets.SetTrigger("Out");
        }
    }
}
