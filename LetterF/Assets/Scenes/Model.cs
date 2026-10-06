using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;


public class Model
{
    List<Vector3Int> faces = new List<Vector3Int>();
    List<Vector3> vertices = new List<Vector3>();

    private List<Vector2> texture_coordinates;
    private List<Vector3Int> texture_index_list;
    public Model()
    {

        texture_coordinates= new List<Vector2>();
        texture_index_list = new List<Vector3Int>();
        addVertices();
        addTextureCoordinates();
        addFaces();
        texture_coordinates = convertUV(1024);
    }
    private List<Vector2> convertUV(float u)
    {
        List<Vector2> temp = new List<Vector2>();
        foreach (var v in texture_coordinates)
        {
            temp.Add(new Vector2(v.x / u, 1 - v.y / u));
        }
        return temp;
    }
    private void addTextureCoordinates()
    {
        texture_coordinates.Add(new Vector2(755, 26));//0
        texture_coordinates.Add(new Vector2(904, 26));//1
        texture_coordinates.Add(new Vector2(970,10));//2
        texture_coordinates.Add(new Vector2(1111, 10));//3
        texture_coordinates.Add(new Vector2(736, 43));//4
        texture_coordinates.Add(new Vector2(1130, 29));//5
        texture_coordinates.Add(new Vector2(736, 66));//6
        texture_coordinates.Add(new Vector2(862, 66));//7
        texture_coordinates.Add(new Vector2(1010, 48));//8
        texture_coordinates.Add(new Vector2(1130, 48));//9
        texture_coordinates.Add(new Vector2(755, 144));//10
        texture_coordinates.Add(new Vector2(862, 144));//11
        texture_coordinates.Add(new Vector2(1010, 123));//12
        texture_coordinates.Add(new Vector2(1111, 123));//13
        texture_coordinates.Add(new Vector2(736, 164));//14
        texture_coordinates.Add(new Vector2(1130,143));//15
        texture_coordinates.Add(new Vector2(736, 185));//16
        texture_coordinates.Add(new Vector2(862, 185));//17
        texture_coordinates.Add(new Vector2(1010,162));//18
        texture_coordinates.Add(new Vector2(1130,162));//19
        texture_coordinates.Add(new Vector2(862, 344));//20
        texture_coordinates.Add(new Vector2(904, 344));//21
        texture_coordinates.Add(new Vector2(970,313));//22
        texture_coordinates.Add(new Vector2(1010,313));//23 
    }

    
    private void addFaces()
    {
        faces.Add(new Vector3Int(1, 2, 4));//0
        texture_index_list.Add(new Vector3Int(3,5,9));//0
        faces.Add(new Vector3Int(3, 1, 4));//1
        texture_index_list.Add(new Vector3Int(8, 3, 9));//1
        faces.Add(new Vector3Int(0, 1, 3));//2
        texture_index_list.Add(new Vector3Int(2, 3, 8));//2
        faces.Add(new Vector3Int(0, 3, 8));//3
        texture_index_list.Add(new Vector3Int(2, 8, 18));//3
        faces.Add(new Vector3Int(0, 8, 10));//4
        texture_index_list.Add(new Vector3Int(2, 18, 22));//4
        faces.Add(new Vector3Int(8, 5, 6));//5
        texture_index_list.Add(new Vector3Int(18, 12, 13));//5
        faces.Add(new Vector3Int(8, 6, 9));//6
        texture_index_list.Add(new Vector3Int(18, 13, 19));//6
        faces.Add(new Vector3Int(6, 7, 9));//7
        texture_index_list.Add(new Vector3Int(13, 15, 19));//7
        faces.Add(new Vector3Int(10, 8, 11));//8
        texture_index_list.Add(new Vector3Int(22, 18, 23));//8

        faces.Add(new Vector3Int(16, 14, 13));//9
        texture_index_list.Add(new Vector3Int(6, 4, 0));//9
        faces.Add(new Vector3Int(16, 13, 15));//10
        texture_index_list.Add(new Vector3Int(6, 0, 7));//10
        faces.Add(new Vector3Int(13, 12, 15));//11
        texture_index_list.Add(new Vector3Int(0, 1, 7));//11
        faces.Add(new Vector3Int(15, 12,20));//12
        texture_index_list.Add(new Vector3Int(7, 1, 17));//12
        faces.Add(new Vector3Int(20, 12, 22));//13
        texture_index_list.Add(new Vector3Int(17, 1, 21));//13
        faces.Add(new Vector3Int(18, 17, 20));//14
        texture_index_list.Add(new Vector3Int(10, 11, 17));//14
        faces.Add(new Vector3Int(21, 18, 20));//15
        texture_index_list.Add(new Vector3Int(16, 10, 17));//15
        faces.Add(new Vector3Int(21, 19, 18));//16
        texture_index_list.Add(new Vector3Int(16, 14, 10));//16
        faces.Add(new Vector3Int(23, 20, 22));//17
        texture_index_list.Add(new Vector3Int(20, 17, 21));//17

        faces.Add(new Vector3Int(1,0,12));//18
        faces.Add(new Vector3Int(1, 12, 13));//19

        faces.Add(new Vector3Int(2, 1, 13));//20
        faces.Add(new Vector3Int(2, 13, 14));//21
        faces.Add(new Vector3Int(4, 2, 14));//22
        faces.Add(new Vector3Int(4, 14, 16));//23

        faces.Add(new Vector3Int(15, 3, 4));//24
        faces.Add(new Vector3Int(16, 15, 4));//25

        faces.Add(new Vector3Int(5, 3, 15));//26
        faces.Add(new Vector3Int(5, 15, 17));//27

        faces.Add(new Vector3Int(6, 5, 17));//28
        faces.Add(new Vector3Int(6, 17, 18));//29

        faces.Add(new Vector3Int(7, 6, 18));//30
        faces.Add(new Vector3Int(19, 7, 18));//31
        faces.Add(new Vector3Int(9, 7, 19));//32
        faces.Add(new Vector3Int(9, 19, 21));//33

        faces.Add(new Vector3Int(20, 8, 9));//34
        faces.Add(new Vector3Int(21, 20, 9));//35

        faces.Add(new Vector3Int(11, 8, 20));//36
        faces.Add(new Vector3Int(11, 20, 23));//37

        faces.Add(new Vector3Int(23,22, 11));//38
        faces.Add(new Vector3Int(22, 10, 11));//39

        faces.Add(new Vector3Int(22, 12, 10));//40
        faces.Add(new Vector3Int(12, 0, 10));//41

    }
    private void addVertices()
    {
        vertices.Add(new Vector3(-4, 8, 1));//0
        vertices.Add(new Vector3(3, 8, 1));//1
        vertices.Add(new Vector3(4, 7, 1));//2
        vertices.Add(new Vector3(-2, 6, 1));//3
        vertices.Add(new Vector3(4, 6, 1));//4

        vertices.Add(new Vector3(-2, 2, 1));//5
        vertices.Add(new Vector3(3, 2, 1));//6
        vertices.Add(new Vector3(4, 1, 1));//7

        vertices.Add(new Vector3(-2, 0, 1));//8
        vertices.Add(new Vector3(4, 0, 1));//9
        vertices.Add(new Vector3(-4, -8, 1));//10
        vertices.Add(new Vector3(-2, -8, 1));//11

        vertices.Add(new Vector3(-4, 8, -1));//12
        vertices.Add(new Vector3(3, 8, -1));//13
        vertices.Add(new Vector3(4, 7, -1));//14
        vertices.Add(new Vector3(-2, 6, -1));//15
        vertices.Add(new Vector3(4, 6, -1));//16

        vertices.Add(new Vector3(-2, 2, -1));//17
        vertices.Add(new Vector3(3, 2, -1));//18
        vertices.Add(new Vector3(4, 1, -1));//19

        vertices.Add(new Vector3(-2, 0, -1));//20
        vertices.Add(new Vector3(4, 0, -1));//21
        vertices.Add(new Vector3(-4, -8, -1));//22
        vertices.Add(new Vector3(-2, -8, -1));//23


    }



    public GameObject CreateUnityGameObject(Texture2D texture)
    {
        Mesh mesh = new Mesh();
        GameObject newGO = new GameObject();

        MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();
        MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();

        List<Vector3> coords = new List<Vector3>();
        List<int> dummy_indices = new List<int>();
        List<Vector2> text_coords = new List<Vector2>();
        //List<Vector3> normalz = new List<Vector3>();

        for (int i = 0; i < faces.Count; i++)
        {
            //Vector3 normal_for_face = normals[i];

            //normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

            coords.Add(vertices[faces[i].x]); dummy_indices.Add(i * 3); text_coords.Add(texture_coordinates[texture_index_list[i].x]);// normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].y]); dummy_indices.Add(i * 3 + 2); text_coords.Add(texture_coordinates[texture_index_list[i].y]); //normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].z]); dummy_indices.Add(i * 3 + 1); text_coords.Add(texture_coordinates[texture_index_list[i].z]); //normalz.Add(normal_for_face);
        }

        mesh.vertices = coords.ToArray();
        mesh.triangles = dummy_indices.ToArray();
        mesh.uv = text_coords.ToArray();
        //mesh.normals = normalz.ToArray();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh_filter.mesh = mesh;

        Material material = new Material(Shader.Find("Standard"));

        material.mainTexture = texture;
        mesh_renderer.material = material;
        return newGO;
    }

    // simple implementation that adds one UV per vertex
    /*private void addTextureCoordinates()
    {
        if (texture_coordinates == null) texture_coordinates = new List<Vector2>();
        texture_coordinates.Clear();
        for (int i = 0; i < vertices.Count; i++)
        {
            texture_coordinates.Add(Vector2.zero);
        }
    }*/
}