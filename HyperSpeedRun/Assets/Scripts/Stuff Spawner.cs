//using UnityEngine;
//using System.Collections;

//public class StuffSpawner : MonoBehaviour
//{


//    public Transform[] StuffSpawnPoints;
//    public GameObject[] Bonus;
//    public GameObject[] Obstacles;

<<<<<<< HEAD
//    public bool RandomX = false;
//    public float minX = -2f, maxX = 2f;
=======
    public bool RandomX = false;
    public float minX = -2f, maxX = 2f;
    private int i;
>>>>>>> 648735d80da3b8d28d21cb16b119eca06fff11c6

//    void CreateObject(Vector3 position, GameObject prefab)
//    {
//        if (RandomX)
//            position += new Vector3(Random.Range(minX, maxX), 0, 0);

//        Instantiate(prefab, position, Quaternion.identity);
//    }

//    void Start()
//    {
//        bool placeObstacle = Random.Range(0, 2) == 0;
//        int obstacleIndex = -1;
//        if (placeObstacle)
//        {
//            obstacleIndex = Random.Range(1, StuffSpawnPoints.Length);

<<<<<<< HEAD
//            CreateObject(StuffSpawnPoints[obstacleIndex].position, Obstacles[Random.Range(0, Obstacles.Length)]);
//        }
        

//        for (int i = 0; i & amp; amp; amp; amp; amp; lt; StuffSpawnPoints.Length; i++)
//       {

//            if (i == obstacleIndex) continue;
//            if (Random.Range(0, 3) == 0)
//            {
//                CreateObject(StuffSpawnPoints[i].position, Bonus[Random.Range(0, Bonus.Length)]);
//            }
//        }

//    }
//}
=======
            CreateObject(StuffSpawnPoints[obstacleIndex].position, Obstacles[Random.Range(0, Obstacles.Length)]);
        }



        for (int i = 0; i < StuffSpawnPoints.Length -1; i++) 
       {

            if (i == obstacleIndex) continue;

            if (Random.Range(0, 3) == 0)
            {
                CreateObject(StuffSpawnPoints[i].position, Bonus[Random.Range(0, Bonus.Length)]);
            }
        }
    }
}
>>>>>>> 648735d80da3b8d28d21cb16b119eca06fff11c6
