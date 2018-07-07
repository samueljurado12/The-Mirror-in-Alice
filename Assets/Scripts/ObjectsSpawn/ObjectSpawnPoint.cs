using UnityEngine;

public class ObjectSpawnPoint : MonoBehaviour {

    public void spawn(GameObject[] spawnableObjects) {
        Instantiate(pickRandomSpawnableObject(spawnableObjects), this.transform);
    }

    private GameObject pickRandomSpawnableObject(GameObject[] objects) {
        return objects[Random.Range(0, objects.Length)];
    }
}
