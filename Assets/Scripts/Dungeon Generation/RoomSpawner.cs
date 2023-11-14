using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    private Room room;

    void Start()
    {
        Invoke("SpawnRandomRoom", 1f);
        room = transform.root.GetComponent<Room>();
    }

    void SpawnRandomRoom()
    {
        GameObject room = Dungeon.Singleton.rooms[Random.Range(0, Dungeon.Singleton.rooms.Count)];

        Instantiate(room, transform.position, Quaternion.identity);
    }
}
