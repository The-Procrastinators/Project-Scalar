﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public GameObject[] rooms;

    void Start()
    {
        int rand = Random.Range(0, rooms.Length);
        Instantiate(rooms[rand], transform.position, Quaternion.identity);
    }
}

    
