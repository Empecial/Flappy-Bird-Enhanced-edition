using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public GameObject ObstaclesPrefab;

    public int PipeSpeed = 80;

    private int timer; 

    void FixedUpdate()
    {
        timer++;
        print("timer is " + timer);

        if (timer>= PipeSpeed)
        {
            timer = 0;
            GameObject NewPipe = Instantiate(ObstaclesPrefab,
                new Vector2(ObstaclesPrefab.transform.position.x, 
                ObstaclesPrefab.transform.position.y + Random.Range(-3f, 3f)), ObstaclesPrefab.transform.rotation);
            Destroy(NewPipe, 6f);
        }
    }
}
