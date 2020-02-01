using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room
{
    public Vector2Int roomCoord;
    public Dictionary<string, Room> neighbors;

    public Room(int x, int y)
    {
        this.roomCoord = new Vector2Int(x, y);
        this.neighbors = new Dictionary<string, Room>();
    }

    public Room(Vector2Int roomCoord)
    {
        this.roomCoord = roomCoord;
        this.neighbors = new Dictionary<string, Room>();
    }

    public List<Vector2Int> NeighborCoord()
    {
        List<Vector2Int> neighborCoordinates = new List<Vector2Int>
        {
            new Vector2Int(this.roomCoord.x, this.roomCoord.y - 1),
            new Vector2Int(this.roomCoord.x + 1, this.roomCoord.y),
            new Vector2Int(this.roomCoord.x, this.roomCoord.y + 1),
            new Vector2Int(this.roomCoord.x - 1, this.roomCoord.y)
        };

        return neighborCoordinates;
    }

    public void Connect(Room neighbor)
    {
        string direction = "";
        if (neighbor.roomCoord.y < this.roomCoord.y)
            direction = "N";
        if (neighbor.roomCoord.x > this.roomCoord.x)
            direction = "E";
        if (neighbor.roomCoord.y > this.roomCoord.y)
            direction = "S";
        if (neighbor.roomCoord.x < this.roomCoord.x)
            direction = "W";
        this.neighbors.Add(direction, neighbor);
    }
}

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField]
    private int nbRoom = 0;
    private Room[,] rooms;

    // Start is called before the first frame update
    void Start()
    {
        Room currentRoom = GenerateDungeon();
        //PrintGrid();
        string roomName = "room" + (int)Random.Range(0, 5);
        GameObject roomObject = (GameObject)Instantiate(Resources.Load(roomName));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Room GenerateDungeon()
    {
        int gridSize = 2 * nbRoom;
        rooms = new Room[gridSize, gridSize];

        Vector2Int initialRoomCoord = new Vector2Int((gridSize / 2) - 1, (gridSize / 2) - 1);

        Queue<Room> roomsToCreate = new Queue<Room>();
        roomsToCreate.Enqueue(new Room(initialRoomCoord.x, initialRoomCoord.y));
        List<Room> createdRooms = new List<Room>();

        while (roomsToCreate.Count > 0 && createdRooms.Count < nbRoom)
        {
            Room currentRoom = roomsToCreate.Dequeue();
            this.rooms[currentRoom.roomCoord.x, currentRoom.roomCoord.y] = currentRoom;
            createdRooms.Add(currentRoom);
            AddNeighbors(currentRoom, roomsToCreate);
        }

        foreach (Room room in createdRooms)
        {
            List<Vector2Int> neighborCoord = room.NeighborCoord();
            foreach (Vector2Int coord in neighborCoord)
            {
                Room neighbor = this.rooms[coord.x, coord.y];
                if (neighbor != null)
                    room.Connect(neighbor);
            }
        }

        return this.rooms[initialRoomCoord.x, initialRoomCoord.y];
    }

    private void AddNeighbors(Room currentRoom, Queue<Room> roomsToCreate)
    {
        List<Vector2Int> neighborsCoord = currentRoom.NeighborCoord();
        List<Vector2Int> availableNeighbors = new List<Vector2Int>();
        foreach (Vector2Int coordinate in neighborsCoord)
        {
            if (this.rooms[coordinate.x, coordinate.y] == null)
            {
                availableNeighbors.Add(coordinate);
            }
        }

        int numberOfNeighbors = (int)Random.Range(1, availableNeighbors.Count);

        for (int neighborIndex = 0; neighborIndex < numberOfNeighbors; neighborIndex++)
        {
            float randomNumber = Random.value;
            float roomFrac = 1f / (float)availableNeighbors.Count;
            Vector2Int chosenNeighbor = new Vector2Int(0, 0);
            foreach (Vector2Int coordinate in availableNeighbors)
            {
                if (randomNumber < roomFrac)
                {
                    chosenNeighbor = coordinate;
                    break;
                }
                else
                {
                    roomFrac += 1f / (float)availableNeighbors.Count;
                }
            }
            roomsToCreate.Enqueue(new Room(chosenNeighbor));
            availableNeighbors.Remove(chosenNeighbor);
        }
    }

    public void PrintGrid()
    {
        for (int i = 0; i < this.rooms.GetLength(1); i++)
        {
            string row = "";
            for (int j = 0; j < this.rooms.GetLength(0); j++)
            {
                if (this.rooms[j, i] == null)
                    row += "X";
                else
                    row += "R";
            }
            Debug.Log(row);
        }
    }
}
