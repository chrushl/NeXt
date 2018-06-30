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
        float step = speed * Time.deltaTime;
        foreach (GameObject player in players)
        {
            if ((Plate.transform.position - player.transform.position).magnitude < 1.5f)
            {
                Debug.Log("Open normal");
                Door.transform.position = Vector3.MoveTowards(Door.transform.position, new Vector3(oldPos.x + moveOnX, oldPos.y + moveOnY, Door.transform.position.z), step);
            }
            else
            {
                if(player.GetComponent<PlayerController>().getActivePlayer() && ((Plate.transform.position - player.transform.position).magnitude < 1.5f))
                {
                    Debug.Log("close");
                    Door.transform.position = Vector3.MoveTowards(Door.transform.position, oldPos, step);
                }
                else if (!player.GetComponent<PlayerController>().getActivePlayer() && ((Plate.transform.position - player.transform.position).magnitude < 1.5f))
                {
                    Debug.Log("close 2");
                    Door.transform.position = Vector3.MoveTowards(Door.transform.position, oldPos, step);
                }
            }
        }
    }

    public void setOldPos()
    {
        Door.transform.position = Vector3.MoveTowards(Door.transform.position, oldPos , 1000000);
    }
}
