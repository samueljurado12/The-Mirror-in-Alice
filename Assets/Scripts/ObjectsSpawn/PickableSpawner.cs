using System.Collections.Generic;
using UnityEngine;

public class PickableSpawner : MonoBehaviour {

    [SerializeField]
    private float maxSpawns;

    private List<ObjectSpawnPoint> possibleSpawnPoints = new List<ObjectSpawnPoint>();


	// Use this for initialization
	void Start () {
        foreach(ObjectSpawnPoint spawnPoint in GetComponentsInChildren<ObjectSpawnPoint>()) {
            possibleSpawnPoints.Add(spawnPoint);
        }

        for(int i = 0; i < maxSpawns; i++) {
            ObjectSpawnPoint selected = pickRandom(possibleSpawnPoints);
            possibleSpawnPoints.Remove(selected);            
            selected.spawn();
        }
        
	}

    private ObjectSpawnPoint pickRandom(List<ObjectSpawnPoint> possibleSpawnPoints) {
        int index = Random.Range(0, possibleSpawnPoints.ToArray().Length);
        return (ObjectSpawnPoint)possibleSpawnPoints.ToArray()[index];
    }
}
