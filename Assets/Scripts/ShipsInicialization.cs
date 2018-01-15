using UnityEngine;
using System.Collections;

public class ShipsInicialization : MonoBehaviour
{

    public GameObject prefab;

    private int whereSetRandom;
    private float xDirRandom;
    private float yDirRandom;

    public float fireRate;
    private float nextFire;


	void Start () 
    {

 	}

    public void MyRandomPositionGenerator()
    {
        whereSetRandom = Random.Range(1, 5);
        xDirRandom = Random.Range(-6.0f, 6.0f);
        yDirRandom = Random.Range(-3.5f, 3.5f);

        if (whereSetRandom == 1) yDirRandom = 4.5f;
        else if (whereSetRandom == 2) yDirRandom = -4.5f;
        else if (whereSetRandom == 3) xDirRandom = 6.5f;
        else if (whereSetRandom == 4) xDirRandom = -6.5f;

        Instantiate(prefab, new Vector3(xDirRandom, yDirRandom, 0), Quaternion.identity);
    }
}
