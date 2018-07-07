using UnityEngine;

public class ObjectSpawnPoint : MonoBehaviour {

    public void spawn(GameObject spawnableObject) {
        Instantiate(spawnableObject, this.transform);
    }

}
