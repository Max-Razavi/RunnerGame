using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 characterPosition = GameObject.Find("Character").transform.position;
        this.transform.position = new Vector3(characterPosition.x + 10, this.transform.position.y, characterPosition.z - 10);
        
    }
}
