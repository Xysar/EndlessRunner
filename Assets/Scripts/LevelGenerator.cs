using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 50f;

    
    [SerializeField] private List<Transform> LevelPartList;
    [SerializeField] private Transform LevelPartStart;
    [SerializeField] private Transform play;
    private Vector3 lastEndPosition;
  


    private void Awake()
    {
        lastEndPosition = LevelPartStart.Find("EndPoint").position;
        
        int startingSpawnLevelParts = 5;
        for(int i = 0; i< startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
     
    }

    private void Update()
    {
        if(Vector3.Distance(play.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
 
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = LevelPartList[Random.Range(0, LevelPartList.Count)];
        Transform LastLevePartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = LastLevePartTransform.Find("EndPoint").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        levelPartTransform.gameObject.GetComponent<DestroyObject>().player = play;
        return levelPartTransform;
    }

    
}
