using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] 
    private ChangeSceneSystem changeSystem;
    
    public void StartGame()
    {
        changeSystem.LoadScene(1);
    }
    
    public void QuitGame()
    {
        Debug.Log($"Exiting Game");
        Application.Quit();
    }
}
