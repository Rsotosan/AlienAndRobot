using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour

{
    [SerializeField]
    public string scene;
    public void changeToNextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }



}