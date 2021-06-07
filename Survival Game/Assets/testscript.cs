using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    [SerializeField]Material shader;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Material>().shader = shader.shader;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
