using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static bool HasInstance() => instance != null;
    
    private static T instance;

    private static bool shuttingDown;
    
    private static object m_Lock = new object();

    private static string initializedScene = "";
    
    public static T Instance
    {
        get
        {
            lock (m_Lock)
            {
                if (shuttingDown && initializedScene == SceneManager.GetActiveScene().name)
                {
                    //Debug.LogWarning("[SingletonSingleScene] Instance '" + typeof(T) +
                    //    "' already destroyed. Returning null.");
                    return null;
                }
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if (instance == null)
                    {
                        Debug.LogError($"[SingletonSingleScene] Instance {typeof(T)} not found on scene");
                        return null;
                    }

                    initializedScene = SceneManager.GetActiveScene().name;

                    SceneManager.sceneUnloaded += SceneUnloadedHandler;
                }

                return instance;
            }
        }
    }
    
    private static void SceneUnloadedHandler(Scene currentScene)
    {
        if (currentScene.name == initializedScene)
        {
            shuttingDown = false;

            SceneManager.sceneUnloaded -= SceneUnloadedHandler;
        }
    }

    protected virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError($"Found duplicate for the {typeof(T)} Singleton");
            Application.Quit();
            return;
        }
    }

    protected virtual void OnApplicationQuit()
    {
        shuttingDown = true;
    }

    protected virtual void OnDestroy()
    {
        shuttingDown = true;
    }
}
