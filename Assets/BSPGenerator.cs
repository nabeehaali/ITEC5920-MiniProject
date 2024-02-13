using System.Collections.Generic;
using UnityEngine;

public class BSPGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public int mazeWidth = 21;
    public int mazeHeight = 21;
    public int iterations = 3;
    public int minRoomLength = 3;
    public int maxRoomLength = 7;

    private bool[,] mazeGrid;
    private List<Room> rooms;

    private void Start()
    {
        GenerateMaze();
    }

    private void GenerateMaze()
    {
        mazeGrid = new bool[mazeWidth, mazeHeight];
        rooms = new List<Room>();

        SplitSpace(0, 0, mazeWidth, mazeHeight, iterations);

        // Fill remaining empty spaces with walls
        for (int x = 0; x < mazeWidth; x++)
        {
            for (int y = 0; y < mazeHeight; y++)
            {
                if (!mazeGrid[x, y])
                {
                    Instantiate(wallPrefab, new Vector3(x, 0.5f, y), Quaternion.identity);
                }
            }
        }

        // Generate rooms
        foreach (Room room in rooms)
        {
            room.GenerateRoom(wallPrefab);
        }
    }

    private void SplitSpace(int x, int y, int width, int height, int iterationsRemaining)
    {
        if (iterationsRemaining <= 0)
        {
            rooms.Add(new Room(x, y, width, height, Random.Range(minRoomLength, maxRoomLength + 1)));
            return;
        }

        bool splitHorizontally = Random.value > 0.5f;
        if (splitHorizontally)
        {
            int split = Random.Range(minRoomLength, height - minRoomLength + 1);
            for (int i = x; i < x + width; i++)
            {
                mazeGrid[i, y + split] = true;
            }
            SplitSpace(x, y, width, split, iterationsRemaining - 1);
            SplitSpace(x, y + split + 1, width, height - split - 1, iterationsRemaining - 1);
        }
        else
        {
            int split = Random.Range(minRoomLength, width - minRoomLength + 1);
            for (int i = y; i < y + height; i++)
            {
                mazeGrid[x + split, i] = true;
            }
            SplitSpace(x, y, split, height, iterationsRemaining - 1);
            SplitSpace(x + split + 1, y, width - split - 1, height, iterationsRemaining - 1);
        }
    }

    private class Room
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public int roomLength;

        public Room(int x, int y, int width, int height, int roomLength)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.roomLength = roomLength;
        }

        public void GenerateRoom(GameObject wallPrefab)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    if (i >= x + (width - roomLength) / 2 && i < x + (width + roomLength) / 2 && j >= y + (height - roomLength) / 2 && j < y + (height + roomLength) / 2)
                    {
                        Instantiate(wallPrefab, new Vector3(i, 0.5f, j), Quaternion.identity);
                    }
                }
            }
        }
    }
}
