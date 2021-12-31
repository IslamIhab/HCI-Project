using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewerEditor : MonoBehaviour
{
    public ChatDemo chat;
    public GameObject Cube;
    public static int color = 0;
    float y = 0.5f;

    public void GenerateRandomCube()
    {
        var position = new Vector3(Random.Range(-2f, 2f), y, Random.Range(-2f, 2f));
        CreateCube(position, color);
        chat.MessageEntered(position.x + "," + position.z + "," + color);
    }

    public void GenerateCube(string cubeData)
    {
        string[] values = cubeData.Split(',');
        var position = new Vector3(float.Parse(values[0]), y, float.Parse(values[1]));
        CreateCube(position, int.Parse(values[2]));
    }

    public void CreateCube(Vector3 position, int col)
    {
        GameObject cube = Instantiate(Cube, position, Quaternion.identity);

        var renderer = cube.GetComponent<Renderer>();

        Color tempColor;
        if (col == 1)
            tempColor = Color.red;
        else if (col == 2)
            tempColor = Color.green;
        else if (col == 3)
            tempColor = Color.blue;
        else
            tempColor = Color.white;

        renderer.material.SetColor("_Color", tempColor);
    }

    public void SetSolor(int col)
    {
        color = col;
    }


}
