using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils;

public class EnemyManager : MonoBehaviour
{
    [Header("Assignables")]
    public GameObject enemyObject;

    [HideInInspector] public Vector2 spawnValues;
    public Point2D spawnWaitRange; 
    public int spawnDelay = 1;

    IEnumerator waitSpawner() {
      yield return new WaitForSeconds(spawnDelay);
      while (true){
          Vector2 spawnPosition = new Vector2( Random.Range(-10,10), Random.Range(-10,10) );
          Instantiate(enemyObject, spawnPosition, gameObject.transform.rotation);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
