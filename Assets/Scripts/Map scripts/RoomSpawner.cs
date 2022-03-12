using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public string OrgDir;
    public GameObject Up;
    public GameObject Down;
    public GameObject Right;
    public GameObject Left;
    public GameObject roomtLUR;
    public GameObject room4;
    public GameObject room4U;
    public GameObject room_IL;
    public GameObject room_IR;
    public GameObject roomIU;
    public GameObject roomTLR;
    public GameObject roomTLU;
    public GameObject roomTRU;
    public GameObject[] rooms;
    private string[] roomNames; 

    //ContactFilter2D cFilter = new ContactFilter2D();
    //Collider2D[] detRooms = new Collider2D[1];
    // Start is called before the first frame update
    void Start()
    {
        rooms = new GameObject[] { roomtLUR, room4, room4U, room_IL, room_IR, roomIU, roomTLR, roomTLU, roomTRU };
        roomNames = new string[] { "roomtLUR", "room4", "room4U", "room_IL", "room_IR", "roomIU", "roomTLR", "roomTLU", "roomTRU" };
        Instantiate(rooms[0], transform.position, transform.rotation);
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
