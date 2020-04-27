using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_initializer : MonoBehaviour
{
    // 生成するゲームオブジェクト
    public GameObject wall_prefab;

    // ----------ここから迷路生成プログラム----------
    private static System.Random rnd = new System.Random();

    /*
        generate random coordinate of wall
        Args:
            - size: int
        Return:
            - coordinate: int, 0 <= coordinate < size and even number
    */
    public static int get_random_coordinate(int size)
    {
        int coordinate;
        coordinate = rnd.Next(0, size);
        coordinate = coordinate % 2 == 0 ? coordinate : coordinate + 1;
        return coordinate;
    }

    /*
        generate random direction of wall
        Return:
            - direction: int, (0 == up, 1 == left, 2 == down, 3 == right)
    */
    public static int get_random_direction()
    {
        return rnd.Next(0, 4);
    }

    /*
        judge path
        Args:
            - maze: int[,]
            - x: int
            - y: int
            - direction: int
        Return:
            - path or not path: bool
    */
    public static bool judge_path(int[,] maze, int x, int y, int direction)
    {
        if (direction == 0){
            if (y-2 >= 0 && maze[x, y-2] == 0) return true;
        }else if(direction == 1){
            if (x-2 >= 0 && maze[x-2, y] == 0) return true;
        }else if(direction == 2){
            if (y+2 < maze.GetLength(1) && maze[x, y+2] == 0) return true;
        }else{
            if (x+2 < maze.GetLength(0) && maze[x+2, y] == 0) return true;
        }
        return false;
    }

    /*
        generate maze
        Args:
            - size: int, must be odd number
        Return:
            - maze: int[,], 0 == path, 1 == wall
    */
    public static int[,] generate_maze(int size)
    {
        int miss_count = 0;
        int x, y;
        int direction;
        bool end_path;
        int[,] maze = new int[size, size];
        // initialize maze
        for (int i = 0; i < size; i++){
            for (int j = 0; j < size; j++){
                if (i == 0 || i == size - 1 || j == 0 || j == size - 1) maze[i, j] = 1;
                else maze[i, j] = 0;
            }
        }

        // generate maze
        while(miss_count < 100){
            x = get_random_coordinate(size);
            y = get_random_coordinate(size);
            if (maze[x, y] == 1){
                end_path = false;
                // generate wall
                do{
                    direction = get_random_direction();
                    for (int i = 0; i < 4; i++){
                        if (judge_path(maze, x, y, direction)){
                            if (direction == 0){
                                maze[x, y-1] = 1;
                                maze[x, y-2] = 1;
                                y = y - 2;
                            }else if(direction == 1){
                                maze[x-1, y] = 1;
                                maze[x-2, y] = 1;
                                x = x - 2;
                            }else if(direction == 2){
                                maze[x, y+1] = 1;
                                maze[x, y+2] = 1;
                                y = y + 2;
                            }else{
                                maze[x+1, y] = 1;
                                maze[x+2, y] = 1;
                                x = x + 2;
                            }
                            miss_count = 0;
                            break;
                        }else{
                            direction = (direction + 1) % 4;
                            if (i == 3){
                                miss_count++;
                                end_path = true;
                            }
                        }
                    }
                }while(end_path == false);
            }else{
                miss_count++;
            }
        }
        return maze;
    }

    // ----------ここまで迷路生成プログラム----------

    void Awake()
    {
        int[,] maze = generate_maze(11);
        for (int x = 0; x < 11; x++){
            for (int z = 0; z < 11; z++){
                if (maze[x, z] == 1){
                    GameObject wall_instance = Instantiate(wall_prefab);
                    wall_instance.transform.position = new Vector3(-50.0f + 10.0f * x, 5.0f, -50.0f + 10.0f * z);
                    wall_instance.transform.parent = this.transform;
                }
            }
        }
    }
}
