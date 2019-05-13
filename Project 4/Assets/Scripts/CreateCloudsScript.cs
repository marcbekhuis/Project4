using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCloudsScript : MonoBehaviour
{
    public GameObject[] clouds = new GameObject[13];
    public GameObject startWall;

    int randomTime;
    float timer;
    bool chooseRandomTime;

    private void Start()
    {
        for(int i = 0; i < 50; i++)
        {
            Instantiate(clouds[Random.Range(0, clouds.Length)], new Vector3(startWall.transform.position.x - Random.Range(0, 200), startWall.transform.position.y + Random.Range(-10f, 10f), 0), new Quaternion(0, 0, 0, 0));
        }
    }    

    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (chooseRandomTime == true)
        {
            randomTime = Random.Range(1, 3);
            chooseRandomTime = false;
        }

        if (timer >= randomTime)
        {
            CloudCreator(Random.Range(0, clouds.Length));
            chooseRandomTime = true;
            timer = 0;
        }
    }

    private void CloudCreator(int randomCloud)
    {
        Instantiate(clouds[randomCloud], new Vector3(startWall.transform.position.x,startWall.transform.position.y + Random.Range(-10f, 10f), 0), new Quaternion(0,0,0,0));
    }
}
