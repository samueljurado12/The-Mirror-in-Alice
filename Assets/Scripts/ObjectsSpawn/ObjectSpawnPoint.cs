using UnityEngine;

public class ObjectSpawnPoint : MonoBehaviour {

    [SerializeField]
    private GameObject[] spawnableObjects;

    public void spawn() {
        Instantiate(pickRandomSpawnableObject(spawnableObjects), this.transform);
    }

    private GameObject pickRandomSpawnableObject(GameObject[] objects) {
        return objects[Random.Range(0, objects.Length)];
    }
}
