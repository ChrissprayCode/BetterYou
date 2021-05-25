using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyButton : MonoBehaviour
{

    public string url;

    public void OpenSurvey()
    {
        Application.OpenURL(url);
    }
}
