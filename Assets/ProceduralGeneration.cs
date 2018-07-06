using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour {


	public List<GameObject> chunks;
	public float speed = 5;
	public int chunksAhead = 3;

	private List<GameObject> generatedChunks;
	private int lastChunkIndex = -1;
	private int numberOfGeneratedChunks = 0;

	// Use this for initialization
	void Start () {
		List<GameObject> startingChunks = new List<GameObject>();
		this.generatedChunks = new List<GameObject> ();
		while (startingChunks.Count < chunksAhead) {
			startingChunks.Add(this.GetChunk());
		}
		Vector2 lastPosition = this.transform.position - new Vector3(10, 0);
		float lastChunkLength = 0f;
		foreach (GameObject chunk in startingChunks) {
			float currentChunkLength = chunk.GetComponent<Chunk>().length;
			lastPosition += new Vector2 (lastChunkLength/2f + currentChunkLength/2, 0);
			lastChunkLength = currentChunkLength;
			GameObject newChunk = Instantiate (chunk, lastPosition, Quaternion.identity) as GameObject;
			this.generatedChunks.Add (newChunk); 
		}

	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < this.generatedChunks.Count; i++) {
			GameObject chunk = this.generatedChunks [i];
			float chunkLength = chunk.GetComponent<Chunk>().length;
			if (chunk.transform.position.x + chunkLength*2 < this.transform.position.x) {
				this.generatedChunks.Remove (chunk);
				GameObject newChunk = this.GetChunk ();
				chunkLength = newChunk.GetComponent<Chunk> ().length;
				Vector2 spawnPosition = this.GetNewSpawnPosition (chunkLength);
				newChunk = Instantiate(newChunk, spawnPosition, Quaternion.identity) as GameObject;
				this.generatedChunks.Add(newChunk);
				Destroy (chunk.gameObject);
			} else {
				chunk.transform.Translate (Vector3.left*speed*Time.deltaTime);
			}
		}
	}

	private GameObject GetChunk() {
		int nextChunkIndex;
		do {
			nextChunkIndex = Random.Range (0, this.chunks.Count);
		} while (nextChunkIndex == this.lastChunkIndex);
		this.lastChunkIndex = nextChunkIndex;
		GameObject newChunk = this.chunks [nextChunkIndex];
		Debug.Log ("Index: " + nextChunkIndex);
		this.numberOfGeneratedChunks++;
		return newChunk;
	}

	private Vector3 GetNewSpawnPosition(float newChunkLength) {
		GameObject lastChunk = this.generatedChunks [this.generatedChunks.Count -1];
		float lastChunkLength = lastChunk.GetComponent<Chunk> ().length;
		return lastChunk.transform.position + new Vector3 (lastChunkLength / 2 + newChunkLength / 2, 0);
	}


}
