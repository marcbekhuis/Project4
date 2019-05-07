using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GameObject infoBook;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (infoBook.activeSelf)
            {
                infoBook.SetActive(false);
            }
            else
            {
                infoBook.SetActive(true);
            }
        }
    }
}
