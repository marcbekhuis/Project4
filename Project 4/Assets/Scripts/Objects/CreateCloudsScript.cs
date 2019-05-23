using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCloudsScript : MonoBehaviour
{
    public GameObject[] clouds = new GameObject[13];
    public GameObject startWall;
    public int cloudAmount = 50;
    public int cloudSpread = 200;

    int randomTime;
    float timer;
    bool chooseRandomTime;

    private void Start()
    {
        //Keeps looping the action as long as cloudAmount is larger than the variable i
        for(int i = 0; i < cloudAmount; i++)
        {
            //Creates clouds with random variables for the length, size and positions.
            Instantiate(clouds[Random.Range(0, clouds.Length)], new Vector3(startWall.transform.position.x - Random.Range(0, cloudSpread), startWall.transform.position.y + Random.Range(-10f, 10f), 0), new Quaternion(0, 0, 0, 0));
        }
    }    

    void Update()
    {
        //Sets a condition dependent on time to call the CloudCreator function
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
        //Instantiator for clouds assigning it a range of random variables
        Instantiate(clouds[randomCloud], new Vector3(startWall.transform.position.x,startWall.transform.position.y + Random.Range(-10f, 10f), 0), new Quaternion(0,0,0,0));
    }
}
