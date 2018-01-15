using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyEnemyOnTriggerEnter : MonoBehaviour {

    public GameObject explosion;

    public float startDelay;

    public int scoreValue;

    public GameController gameController;


    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);

            GameObject explosionClone = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
            Destroy(explosionClone, startDelay);

            gameController.SetScoreText(scoreValue);
            gameController.spawnDestroy -= 1;
        }
    }

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("Player");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void Update()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                // Create a particle if hit
                if (Physics.Raycast(ray) && gameObject.name == "enemy")
                    Destroy(gameObject);
                    gameController.SetScoreText(scoreValue);
                    gameController.spawnDestroy -= 1;
            }
        }
    }

}
