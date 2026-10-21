
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class GraphicsPipeline : MonoBehaviour
{
    public Texture2D texture;
    void Start()
    {
        Model myModel = new Model();
        myModel.CreateUnityGameObject(texture);

        List<Vector3> verts3 = myModel.vertices;
        List<Vector4> verts = Homog(verts3);
        //Display(verts);
        //First Transformation
        //Rotation by 3 degrees about (21, 2, 2).normalized
        Vector3 axis = (new Vector3(21, 2, 2).normalized);
        Matrix4x4 rotationMatrix = Matrix4x4.TRS(
            Vector3.zero,
            Quaternion.AngleAxis(3, axis),
            Vector3.one);
        //Display(rotationMatrix);

        List<Vector4> imageAfterRotation = MatrixTransform(rotationMatrix, verts);
        // Display(imageAfterRotation);

        //2nd Transformation Scale by (3,5,2)
        Matrix4x4 scaleMatrix = Matrix4x4.TRS(
            Vector3.zero,
            Quaternion.identity,
            new Vector3(3, 5, 2)
            );
        //Display(scaleMatrix);

        List<Vector4> imageAfterScale = MatrixTransform(scaleMatrix, imageAfterRotation);
        // Display(imageAfterScale);
        Matrix4x4 translationMatrix = Matrix4x4.TRS(
             new Vector3(-2, 0, 3),
             Quaternion.identity,
             Vector3.one
             );
        //Display(translationMatrix);
        List<Vector4> imageAfterTranslation = MatrixTransform(translationMatrix, verts);
        //Display(imageAfterTranslation);
        Matrix4x4 singleMatrixOfTransformation = translationMatrix * scaleMatrix * rotationMatrix;

       //Display(singleMatrixOfTransformation);

        Vector3 camPosition = new Vector3(23, 5, 52);
        Vector3 camLookAt = new Vector3(2, 3, 2);
        Vector3 camUp = new Vector3(3, 2, 21);

        Matrix4x4 viewingMatrix = Matrix4x4.LookAt(camPosition, camLookAt, Vector3.up);

       //  Display(viewingMatrix);

        List<Vector4> imageAfterViewingMatrix = MatrixTransform(viewingMatrix, imageAfterTranslation);

        // Display(imageAfterViewingMatrix);

        List<Vector4> imageAfterSingleMatrix = MatrixTransform(singleMatrixOfTransformation, verts);

        //Display(imageAfterSingleMatrix);


    }
    private List<Vector4> Homog(List<Vector3> vertices)
    {
        List<Vector4> result = new List<Vector4>();
        foreach (Vector3 v in vertices)
        {
            result.Add(new Vector4(v.x, v.y, v.z, 1f));
        }
        return result;
    }
    private List<Vector4> MatrixTransform(Matrix4x4 matrix, List<Vector4> verts)
    {
        List<Vector4> hold = new List<Vector4>();
        foreach (Vector3 v in verts)
        {
            hold.Add(matrix * v);

        }
        return hold;
    }
    void Display(List<Vector4> verts)
    {
        foreach (Vector4 v in verts)
        {
            print(v);
        }
    }
    void Display(Matrix4x4 matrix)
    {
        for (int i = 0; i < 4; i++)
        {
            {
                print(matrix.GetRow(i));
            }
        }
    }


}