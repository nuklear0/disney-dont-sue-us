using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTLevelLoad : MonoBehaviour {
    [SerializeField] private GameObject road;
    [SerializeField] private GameObject roadTurn;
    [SerializeField] private int numberOfRoads;
    [SerializeField] private GameObject [] enemies;
    private Block[] blocks;
	// Use this for initialization
	void Start () {
        float lengthZ = road.GetComponent<BoxCollider>().bounds.size.z;
        float lengthX = road.GetComponent<BoxCollider>().bounds.size.x;
        blocks = new Block[numberOfRoads];
        blocks[0] = new Block(transform.position, 0);
        Vector3 previousPos = road.transform.position;
        for (int i = 1; i < numberOfRoads; i++)
        {
            int rnd = Random.Range(0, 3);
            while(rnd + blocks[i - 1].getDir() == 3)
            {
                rnd = Random.Range(0, 3);
            }
            switch (rnd)
            {
                case 0:
                    previousPos = new Vector3(previousPos.x, previousPos.y, previousPos.z + lengthZ);
                    break;
                case 1:
                    previousPos = new Vector3(previousPos.x + lengthX, previousPos.y, previousPos.z);
                    break;
                case 2:
                    previousPos = new Vector3(previousPos.x - lengthX, previousPos.y, previousPos.z);
                    break;
            }
            blocks[i] = new Block(previousPos, rnd);
        }
        createBlocks();
        Destroy(road);
	}

    private void print()
    {
        foreach(Block b in blocks)
        {
            Debug.Log(b.getPos() + " " + b.getDir());
        }
    }

    public int [] getDirections()
    {
        int[] array = new int[blocks.Length];
        for(int i = 0; i < blocks.Length; i++)
        {
            array[i] = blocks[i].getDir();
        }
        return array;
    }

    public Vector3[] getPositions()
    {
        Vector3[] array = new Vector3[blocks.Length];
        for (int i = 0; i < blocks.Length; i++)
        {
            array[i] = blocks[i].getPos();
        }
        return array;
    }
    private void createBlocks()
    {
        for(int i = 0; i < blocks.Length-1; i++)
        {
            int rnd = Random.Range(0, 2);
            int rndEnemy = Random.Range(0, enemies.Length);
            switch (blocks[i].getDir())
            {
                case 0:
                    switch (blocks[i+1].getDir())
                    {
                        case 0:
                            Instantiate(road, blocks[i].getPos(), Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(roadTurn, blocks[i].getPos(), Quaternion.Euler(0, 270, 0));
                            break;
                        case 2:
                            Instantiate(roadTurn, blocks[i].getPos(), Quaternion.identity);
                            break;
                    }
                    break;
                case 1:
                    switch (blocks[i + 1].getDir())
                    {
                        case 0:
                            Instantiate(roadTurn, blocks[i].getPos(), Quaternion.Euler(0, 90, 0));
                            break;
                        case 1:
                            Instantiate(road, blocks[i].getPos(), Quaternion.Euler(0,90,0));
                            break;
                        case 2:
                            Debug.Log("FUCK");
                            break;
                    }
                    break;
                case 2:
                    switch (blocks[i + 1].getDir())
                    {
                        case 0:
                            Instantiate(roadTurn, blocks[i].getPos(), Quaternion.Euler(0, 180, 0));
                            break;
                        case 1:
                            Debug.Log("FUCK");
                            break;
                        case 2:
                            Instantiate(road, blocks[i].getPos(), Quaternion.Euler(0, 90, 0));
                            break;
                    }
                    break;
            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
    private class Block
    {
        private Vector3 position;
        private int direction;

        public Block(Vector3 pos, int dir)
        {
            position = pos;
            direction = dir;
        }

        public Vector3 getPos()
        {
            return position;
        }
        public int getDir()
        {
            return direction;
        }
    }
}
