using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Worl : MonoBehaviour
{
    public float speed;

    public List<GameObject> obstacles;

    public List<GameObject> obstaclePrefabs;
    public List<GameObject> hardObstaclePrefabs;

    public float obstacleInterval;
    private float toNextObstacle;

    public float multipleObstacleProbability;
    public float hardObstacleProbability;

    public BeanTempleRunMove player;

    public float offset;

    public Text scoreText;
    public float score;

    private void Start()
    {
        toNextObstacle = obstacleInterval;
    }

    private void FixedUpdate()
    {
        score += speed;
        scoreText.text = "Score: " + (int)score;
        toNextObstacle -= speed;
        transform.position -= new Vector3(0, 0, speed);

        if(toNextObstacle <= 0)
        {
            toNextObstacle = obstacleInterval;
            SpawnObstacles();
        }

        foreach(GameObject go in obstacles)
        {
            if(go.transform.position.z < -20)
            {
                obstacles.Remove(go);
                Destroy(go);
                return;
            }
        }
    }

    public void SpawnObstacles()
    {
        int track = Random.Range(0, 3);
        if (Random.Range(0, 100) < hardObstacleProbability)
        {
            obstacles.Add(Instantiate(hardObstaclePrefabs[Random.Range(0, hardObstaclePrefabs.Count)], new Vector3(player.tracks[track].x, 1, offset), Quaternion.identity, transform));
        }
        else
        {
            obstacles.Add(Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)], new Vector3(player.tracks[track].x, 0.5f, offset), Quaternion.identity, transform));
        }

        if (Random.Range(0, 100) < multipleObstacleProbability)
        {
            int newTrack = track;
            while(newTrack == track)
            {
                newTrack = Random.Range(0, 3);
            }
            obstacles.Add(Instantiate(hardObstaclePrefabs[Random.Range(0, hardObstaclePrefabs.Count)], new Vector3(player.tracks[newTrack].x, 0.5f, offset), Quaternion.identity, transform));
        }
    }
}
