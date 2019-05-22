using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int preferredScene;

    public void SceneChanger()
    {
        //changes the scene to the prefereed scene
        SceneManager.LoadScene(preferredScene);
    }
}
