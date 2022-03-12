using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public GameObject Spawner ;
    public GameObject selfRef;
    public Collider2D Center;
    public GameObject Up;
    public GameObject Down;
    public GameObject Right;
    public GameObject Left;
    public bool spawned = false;
    ContactFilter2D cFilter = new ContactFilter2D();
    Collider2D[] detRooms = new Collider2D[1];

    // Start is called before the first frame update
    void Start()
    {
        //test 
        //Instantiate(testRoom, Up.transform.position, Up.transform.rotation);
        //Instantiate(testRoom, Right.transform.position, Right.transform.rotation);
        //Instantiate(testRoom, Down.transform.position, Down.transform.rotation);
        //Instantiate(testRoom, Left.transform.position, Left.transform.rotation);
    }

    //spawn spawners when player enters room
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (spawned == false)
        {
            RoomSpawner RSpawner;
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("player entered " + selfRef.name);
                //spawn room spawners
                if (Up != null)
                {
                    //Debug.Log("Up valid");
                    RSpawner = SpawnRSpawner(Up);
                    //RSpawner.OrgDir = "U";
                }
                if (Down != null)
                {
                    //Debug.Log("Down valid");
                    RSpawner = SpawnRSpawner(Down);
                    //RSpawner.OrgDir = "D";
                }
                if (Right != null)
                {
                    //Debug.Log("Right valid");
                    RSpawner = SpawnRSpawner(Right);
                    //RSpawner.OrgDir = "R";
                }
                if (Left != null)
                {
                    //Debug.Log("Left valid");
                    RSpawner = SpawnRSpawner(Left);
                    //RSpawner.OrgDir = "L";
                }
                spawned = true;
                Debug.Log("spawning deactivated");
            }
        }
    }

    //if im being honest the naming convention is trash

    RoomSpawner SpawnRSpawner(GameObject loc)// spawns RoomSpawner
    {
        RoomSpawner SpawnerScript = null; //instantiate blank RoomSpawner
        if(Physics2D.OverlapPoint(loc.transform.position, cFilter, detRooms) == 0) //check if not occupied
        {
            GameObject RSpawner = Instantiate(Spawner, loc.transform.position, loc.transform.rotation);
            SpawnerScript = RSpawner.GetComponent<RoomSpawner>();
            Debug.Log(loc.name+" Spawned");
        }
        else
        {
            for (int i = 0; i < detRooms.Length; i++)
            {
                if (detRooms[i].tag != "Room")
                {
                    GameObject RSpawner = Instantiate(Spawner, loc.transform.position, loc.transform.rotation);
                    SpawnerScript = RSpawner.GetComponent<RoomSpawner>();
                    Debug.Log(loc.name + " Spawned");
                }
                else
                {
                    Debug.Log("There is a room at "+loc.name);
                }
            }
        }
        
        
        return SpawnerScript;
    }
}
