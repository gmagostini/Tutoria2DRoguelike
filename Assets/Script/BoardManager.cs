using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count{
        public int minimum;
        public int maximum;
        public Count ( int min, int max){
            minimum = min;
            maximum = max;
        }
    }

    public int collum = 8;
    public int row = 8;
    public Count wallcount = new Count(5,9);
    public Count foodCount = new Count(1,5);

    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] enemyTiles;
    public GameObject[] outerWallTiles;

    private Transform boardHolder;
    private List<Vector2> gridPosition = new List<Vector2>();
    void InitilizeList()
    {
        gridPosition.Clear();
        
        for (int x = 1; x < collum -1; x++ ){
            for (int y = 1; y < row -1 ; y++)
            {
                gridPosition.Add(new Vector3(x,y,0f));

            }
        }
    }

    void BoardSetup(){
        boardHolder = new GameObject ("Board").transform;
        for (int x = -1; x < collum +1; x++ ){
            for (int y = -1; y < row +1 ; y++)
            {
                GameObject toIstantiate = floorTiles[Random.Range(0,floorTiles.Length)];
                if(x == -1 || x == collum || y == -1 || y == row){
                    toIstantiate = outerWallTiles[Random.Range(0,outerWallTiles.Length)];

                }

                GameObject istance = Instantiate(toIstantiate,new Vector2 (x,y), Quaternion.identity);

                istance.transform.SetParent(boardHolder);

            }
        }
    }

    Vector2 RandomPosition(){
        int randomIndex = Random.Range(0,gridPosition.Count);
        Vector2 randomPosition = gridPosition[randomIndex];
        gridPosition.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjetcAtRandom ( GameObject[] tileArray,int Minimun, int maximum){
        int objectCounter = Random.Range (Minimun, maximum +1);
        for (int i = 0; i < objectCounter; i++)
        {
            Vector2 randomPosition = RandomPosition();
            GameObject tileChoise = tileArray[Random.Range(0,tileArray.Length)];
            Instantiate (tileChoise,randomPosition,Quaternion.identity);
        }
    }

    public void SetupScene (int Level){
        BoardSetup();
        InitilizeList();
        LayoutObjetcAtRandom(wallTiles,wallcount.minimum, wallcount.maximum);
        LayoutObjetcAtRandom(foodTiles,foodCount.maximum, foodCount.maximum);
        int enemyCount = (int)Mathf.Log(Level,2f);
        LayoutObjetcAtRandom(enemyTiles,enemyCount,enemyCount);
        Instantiate(exit, new Vector2(collum-1,row-1),Quaternion.identity);
    }
    
}
