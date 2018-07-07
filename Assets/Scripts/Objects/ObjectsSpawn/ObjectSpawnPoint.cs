using UnityEngine;

public class ObjectSpawnPoint : MonoBehaviour {

    public void spawn(GameObject spawnableObject) {
        Instantiate(spawnableObject, this.transform);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(this.transform.position, 0.25f);
    }

}
