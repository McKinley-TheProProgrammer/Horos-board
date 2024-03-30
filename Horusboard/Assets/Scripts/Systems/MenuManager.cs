using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] 
    private ChangeSceneSystem changeSystem;

    [SerializeField]
    private Sound mainTheme;
    private void Start()
    {
        AudioManager.Instance.Play(mainTheme);
    }

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
