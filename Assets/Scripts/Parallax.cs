using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private GameObject fondoUno;
    [SerializeField] private GameObject fondoDos;
    [SerializeField] private GameObject fondoTres;
    [SerializeField] private float velocidadScrolling;
    private Renderer fondoU, fondoD, fondoT;
    private float iniCamX, diffcamX;
    public Vector2 minCamPos, maxCamPos;
    public GameObject seguir;
    public float movSuave;
    private Vector2 velovidad;
    // Start is called before the first frame update
    void Start()
    {
        fondoU = fondoUno.GetComponent<Renderer>();
        fondoD = fondoDos.GetComponent<Renderer>();
        fondoT = fondoTres.GetComponent<Renderer>();
        iniCamX = transform.position.x;
      

       
        
    }

    // Update is called once per frame
    void Update()
    {
        diffcamX = iniCamX - transform.position.x;
        fondoU.material.mainTextureOffset = new Vector2(diffcamX * velocidadScrolling * -1, 0.0f);
        fondoD.material.mainTextureOffset = new Vector2(diffcamX * (velocidadScrolling * 1.5f * -1), 0 - 0f);
        fondoT.material.mainTextureOffset = new Vector2(diffcamX * velocidadScrolling* -1, 0);
        fondoUno.transform.position = new Vector3(fondoUno.transform.position.x, fondoUno.transform.position.y, fondoUno.transform.position.z);
        fondoDos.transform.position = new Vector3(fondoDos.transform.position.x, fondoDos.transform.position.y, fondoDos.transform.position.z);
        fondoTres.transform.position = new Vector3(fondoTres.transform.position.x, fondoTres.transform.position.y, fondoTres.transform.position.z);


        float posX = Mathf.SmoothDamp(transform.position.x, seguir.transform.position.x, ref velovidad.x, movSuave);
        float posY = Mathf.SmoothDamp(transform.position.y, seguir.transform.position.y, ref velovidad.y, movSuave);
        transform.position = new Vector3(Mathf.Clamp(posX, minCamPos.x, maxCamPos.x), Mathf.Clamp(posY, minCamPos.y, maxCamPos.y), transform.position.z);


     

        
    }
}
