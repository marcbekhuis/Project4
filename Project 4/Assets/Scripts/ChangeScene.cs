using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int preferredScene;

    public void SheneChanger()
    {
        SceneManager.LoadScene(preferredScene);
    }
}
