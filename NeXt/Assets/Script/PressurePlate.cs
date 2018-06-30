using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public GameObject[] players;
    public Transform Plate;
    public GameObject Door;
    public float moveOnX;
    public float moveOnY;
    private bool isPressed = false;
    public float speed;
    private Vector3 oldPos;

    void Start()
    {
        oldPos = new Vector3(Door.transform.position.x, Door.transform.position.y);
    }


    // Update is called once per frame
    void Update ()
    {
        foreach(GameObject player in players)
        {
            if ((Plate.transform.position - player.transform.position).magnitude < 1.0f)
            {
                float step = speed * Time.deltaTime;
                Door.transform.position = Vector3.MoveTowards(Door.transform.position, new Vector3(oldPos.x + moveOnX, oldPos.y + moveOnY, Door.transform.position.z), step);
            }
        }
    }

    public void setOldPos()
    {
        Door.transform.position = Vector3.MoveTowards(Door.transform.position, oldPos , 1000000);
    }
}
