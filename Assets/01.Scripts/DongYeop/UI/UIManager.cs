using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int _changeSceneNum;

    public void SceneChange()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_changeSceneNum);
    }

    public void Exit()
    {
        Time.timeScale = 1;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
