using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneScript : MonoBehaviour
{
    public void SceneLoader(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

}
