using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toMoveTheGameObject : MonoBehaviour {

    public Animator ani;
    public VirtualJoystick joystick;

	// Update is called once per frame
	void Update () {
        ani.transform.LookAt(transform);

        float speed = 5.0f;

        if (transform.rotation.x < 180)
        {
            transform.Rotate(Vector3.up, joystick.Horizontal() * speed);
        }
        else
        {
            transform.Rotate(Vector3.up, - joystick.Horizontal() * speed);
        }

        //if (transform.rotation.y < 180)
        //{
        //    transform.Rotate(Vector3.left, joystick.vertical() * speed);
        //}
        //else
        //{
        //    transform.Rotate(Vector3.left, -joystick.vertical() * speed);
        //}
	}
}
