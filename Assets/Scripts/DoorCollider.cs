using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            string roomName = "room" + (int)Random.Range(0, 8);
            collision.gameObject.transform.position = new Vector3(0, 0, 0);
            GameObject dungeon = GameObject.FindGameObjectWithTag("Dungeon");
            DungeonGenerator generator = dungeon.GetComponent<DungeonGenerator>();
//            if (generator.currentRoom.neighbors)
            GameObject.Instantiate(Resources.Load(roomName));
            Destroy(generator.roomObject);
        }
    }
}
