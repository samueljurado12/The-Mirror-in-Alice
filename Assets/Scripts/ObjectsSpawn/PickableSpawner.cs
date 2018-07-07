using System.Collections.Generic;
using UnityEngine;

public class PickableSpawner : MonoBehaviour {

    [SerializeField]
    private float maxSpawns;
    [SerializeField]
    private GameObject[] spawnableObjects;

    private List<ObjectSpawnPoint> possibleSpawnPositions = new List<ObjectSpawnPoint>();


	// Use this for initialization
	void Start () {
        foreach(ObjectSpawnPoint spawnPoint in GetComponentsInChildren<ObjectSpawnPoint>()) {
            possibleSpawnPositions.Add(spawnPoint);
        }

        for(int i = 0; i < maxSpawns; i++) {
            ObjectSpawnPoint selected = pickRandomPosition(possibleSpawnPositions);
            possibleSpawnPositions.Remove(selected);            
            selected.spawn(spawnableObjects);
        }
        
	}

    private ObjectSpawnPoint pickRandomPosition(List<ObjectSpawnPoint> possibleSpawnPositions) {
        int index = Random.Range(0, possibleSpawnPositions.ToArray().Length);
        return (ObjectSpawnPoint)possibleSpawnPositions.ToArray()[index];
    }
}
