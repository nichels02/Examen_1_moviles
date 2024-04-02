using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    [SerializeField] Observador ElObservador;
    [SerializeField] float Profundidad;
    [SerializeField] float PosicionZReal;
    [SerializeField] float limiteDeTiempo;
    [SerializeField] float Tiempo;
    [SerializeField] float DistanciaEsperada;
    [SerializeField] Vector3 laPosicionInicial;
    bool ContarTiempo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ContarTiempo&& Tiempo < limiteDeTiempo)
        {
            Tiempo += Time.deltaTime;
        }
        else if(ContarTiempo)
        {
            Tiempo = 0;
            laPosicionInicial = ElObservador.ElObjeto.transform.position;
        }
        if (Input.touchCount > 0)
        {
            UnityEngine.Touch ElTouch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(ElTouch.position);
            Vector3 posicionDelTouch = ray.GetPoint(Profundidad);
            posicionDelTouch.z = PosicionZReal;
            ElObservador.transform.position= posicionDelTouch;
            
            

            if(ElTouch.phase == TouchPhase.Began && ElObservador.ElObjeto != null)
            {
                ElObservador.ElObjeto.transform.parent = ElObservador.transform;
                ElObservador.ElObjeto.transform.position = new Vector3(ElObservador.transform.position.x, ElObservador.transform.position.y, ElObservador.ElObjeto.transform.position.z);
                laPosicionInicial = ElObservador.ElObjeto.transform.position;
                ContarTiempo = true;
            }
            if (ElTouch.phase == TouchPhase.Ended && Vector3.Distance(ElObservador.ElObjeto.transform.position, laPosicionInicial) < DistanciaEsperada && Tiempo < limiteDeTiempo)
            {

            }
        }


        
    }
}
