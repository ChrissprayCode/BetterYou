using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    [SerializeField] private GameObject CreditsUI;

    public void scene_changer(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public void doExitGame()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }

    public void closeCredits()
    {
        CreditsUI.SetActive(false);
    }

    public void openCredits()
    {
        CreditsUI.SetActive(true);
    }





}
