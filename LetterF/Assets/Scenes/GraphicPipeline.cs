using UnityEngine;

public class GraphicsPipeline : MonoBehaviour
{
    public Texture2D texture;
    void Start()
    {
        Model myModel = new Model();
        myModel.CreateUnityGameObject(texture);
    }
    void Update()
    {

    }
}