using UnityEngine;
using System.Collections;

public class SetLocalEulerAngles : MonoBehaviour {


    public Transform target;
    public bool ruszajsie = true;

    public float speed = 0.5f;


    void Update () 
    {

        if (ruszajsie)
        {
            float step = speed * Time.deltaTime;

            Vector3 v3 = target.right - (Vector3.Dot(target.right, transform.forward) * transform.forward);
            Quaternion q = Quaternion.FromToRotation(transform.right, v3);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, step);
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
       
	}

    public void SetSpeed(float setSpeed)
    {
        speed = speed + setSpeed;
    }
}