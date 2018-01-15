using UnityEngine;
using System.Collections;

public class PlanetHealth : MonoBehaviour {


    public float health;
    public float startDelay;

    public GameObject explosion;

    public DestroyEnemyOnTriggerEnter destroyEnemyOnTriggerEnter;
    public GameController gameController;

    void OnTriggerEnter2D(Collider2D other)
    {

        Destroy(other.gameObject);

        GameObject explosionClone = Instantiate(explosion, other.transform.position, other.transform.rotation) as GameObject;
        Destroy(explosionClone, startDelay);

        health -= destroyEnemyOnTriggerEnter.scoreValue;
        gameController.SetHealthText(health);
        gameController.spawnDestroy -= 1;
    }

	// Use this for initialization
	void Start () 
    {
        health = 100.0f;
        gameController.SetHealthText(health);
    }

    void Update ()
    {
       
    }
	

}
