
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class GraphicsPipeline : MonoBehaviour
{
    public Texture2D texture;
    public Outcode outcode;
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
        List<Vector4> imageAfterTranslation = MatrixTransform(translationMatrix, imageAfterScale);
        //Display(imageAfterTranslation);
        Matrix4x4 singleMatrixOfTransformation = translationMatrix * scaleMatrix * rotationMatrix;

      // Display(singleMatrixOfTransformation);

        List<Vector4> imageAfterTransformation = MatrixTransform(singleMatrixOfTransformation, verts);
      // Display(imageAfterTransformation);

        Vector3 camPosition = new Vector3(23, 5, 52);
        Vector3 camLookAt = new Vector3(2, 3, 2);
        Vector3 camUp = new Vector3(3, 2, 21);

        Matrix4x4 viewingMatrix = Matrix4x4.LookAt(camPosition, camLookAt, Vector3.up);

       //  Display(viewingMatrix);

        List<Vector4> imageAfterViewingMatrix = MatrixTransform(viewingMatrix, imageAfterTranslation);

        // Display(imageAfterViewingMatrix);

        List<Vector4> imageAfterSingleMatrix = MatrixTransform(singleMatrixOfTransformation, verts);

        //Display(imageAfterSingleMatrix);

        //Test Outcodes
        Outcode oc1 = new Outcode(new Vector2(-1, 1.5f));
        Outcode oc2 = new Outcode(new Vector2(1.8f, 1.2f));
       // oc1.display();
        //oc2.display();
       // (oc1 + oc2).display();
        //(oc1 * oc2).display();

        //Not in Viewport
        Vector2 lineStart1 = new Vector2( 0.5f, -2);
        Vector2 lineEnd1 = new Vector2(1, -2);

        Vector2 lineStart2 = new Vector2(0.5f, 2);
        Vector2 lineEnd2 = new Vector2(1, 2);

        Vector2 lineStart3 = new Vector2( -2, 0.5f);
        Vector2 lineEnd3 = new Vector2( -2, 1);

        Vector2 lineStart4 = new Vector2(2, 0.5f);
        Vector2 lineEnd4 = new Vector2(2, 1);

        // In Viewport
        Vector2 lineStart5 = new Vector2(0, 0);
        Vector2 lineEnd5 = new Vector2(1, 1);

        //Part of line in Viewport
        //Clipped at top edge
        Vector2 lineStart6 = new Vector2(0.1f, 2);
        Vector2 lineEnd6 = new Vector2(0f, 0.5f);

        //clipped at bottom edge
        Vector2 lineStart7 = new Vector2(0.5f, 0.2f);
        Vector2 lineEnd7 = new Vector2(0.7f, -2);

        //clipped at right edge
        Vector2 lineStart8 = new Vector2(2, 0.7f);
        Vector2 lineEnd8 = new Vector2(0.5f, 0.4f);

        //clipped at left edge
        Vector2 lineStart9 = new Vector2(0.5f, 0.3f);
        Vector2 lineEnd9 = new Vector2(0.7f, 2);

        //Start and enpoint outside viewport but part of line inside viewport
        Vector2 lineStart10 = new Vector2(0.7f, 2);
        Vector2 lineEnd10 = new Vector2(0.5f, -2);

        //Start and enpoint outside viewport but all line is outside viewport
        Vector2 lineStart11 = new Vector2(-1, 2);
        Vector2 lineEnd11 = new Vector2(1, 3);

        print("Line: ("+lineStart1+", "+lineEnd1+") - "+LineClip(ref lineStart1, ref lineEnd1));
        print("Line: ("+lineStart2+", "+lineEnd2+") - "+LineClip(ref lineStart2, ref lineEnd2));
        print("Line: ("+lineStart3+", "+lineEnd3+") - "+LineClip(ref lineStart3, ref lineEnd3));
        print("Line: ("+lineStart4+", "+lineEnd4+") - "+LineClip(ref lineStart4, ref lineEnd4));
        print("Line: ("+lineStart5+", "+lineEnd5+") - "+LineClip(ref lineStart5, ref lineEnd5));
        print("Line: ("+lineStart6+", "+lineEnd6+") - "+LineClip(ref lineStart6, ref lineEnd6));
        print("Line: ("+lineStart7+", "+lineEnd7+") - "+LineClip(ref lineStart7, ref lineEnd7));
        print("Line: ("+lineStart8+", "+lineEnd8+") - "+LineClip(ref lineStart8, ref lineEnd8));
        print("Line: ("+lineStart9+", "+lineEnd9+") - "+LineClip(ref lineStart9, ref lineEnd9));
        print("Line: (" + lineStart10 + ", " + lineEnd10 + ") - " + LineClip(ref lineStart10, ref lineEnd10));
        print("Line: (" + lineStart11 + ", " + lineEnd11 + ") - " + LineClip(ref lineStart11, ref lineEnd11));

    }
    public bool LineClip(ref Vector2 start, ref Vector2 end)
    {
        Outcode startCode = new Outcode(start);
        Outcode endCode = new Outcode(end);
        Outcode inViewport = new Outcode();

        //trivially accepted
        if((startCode + endCode) == inViewport)
        {
            return true;
        }
        //trivially rejected
        if((startCode * endCode) != inViewport)
        {
            return false;
        }

        if(startCode == inViewport)
        {
            return LineClip(ref end, ref start);
        }
       //if we are here start is not in viewport
       //if(x1=x0){top or bottom, return(x1,1 (x1, -1)}

        float m= (end.y - start.y) / (end.x - start.x);

        if (startCode.up)
        {
            // clip with top edge, y=1
            start.x = start.x + (1 - start.y) / m;
            start.y = 1;
            print("Clipping with top edge: " + new Vector2(start.x, start.y));
            return LineClip(ref start, ref end);
        }
        if(startCode.down)
        {
            // clip with bottom edge, y=-1
            start.x = start.x + (-1 - start.y) / m;
            start.y = -1;
            print("Clipping with bottom edge: "+new Vector2(start.x, start.y));
            return LineClip(ref start, ref end);
        }
        if (startCode.right)
        {
            // clip with right edge, x=1
            start.y = start.y + (1 - start.x) * m;
            start.x = 1;
            print("Clipping with right edge: " + new Vector2(start.x, start.y));
            return LineClip(ref start, ref end);
        }
        if (startCode.left)
        {
            // clip with left edge, x=-1
            start.y = start.y + (-1 - start.x) * m;
            start.x = -1;
            print("Clipping with left edge: " + new Vector2(start.x, start.y));
            return LineClip(ref start, ref end);
        }
        return false;
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