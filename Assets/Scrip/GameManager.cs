using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     Renderer render;
     Texture[] textures;
    int textureNumber;
    float transparenceNumber;
    void Start()
    {
        render = GetComponent<Renderer>();
        textures = Resources.LoadAll<Texture>("Textures");
        ChangeTexture();
        transparenceNumber = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ChangeTexture();
        if (Input.GetKeyDown(KeyCode.UpArrow)) changeTransparence("more");
        if (Input.GetKeyDown(KeyCode.DownArrow)) changeTransparence("low");
    }

    void ChangeTexture()
    {
        textureNumber++;
        if (textureNumber >= textures.Length ) textureNumber = 0;
        render.material.SetTexture("_Texture", textures[textureNumber]);
    }
    void changeTransparence(string type)
    {
        if (type == "more") transparenceNumber += 0.2f ;
        else if(type == "low")transparenceNumber -= 0.2f;
        if (transparenceNumber > 1) transparenceNumber = 1;
        if (transparenceNumber < 0) transparenceNumber = 0;
        render.material.SetFloat("_Transparence", transparenceNumber);
    }

}
