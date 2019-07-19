using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject asteroid;

    private float min_X = -2.7f;
    private float max_X = 2.7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning() {
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        GameObject a = Instantiate(asteroid);
        float x = Random.Range(min_X, max_X);
        a.transform.position = new Vector2(x, transform.position.y);

        StartCoroutine(StartSpawning());
    }
}
