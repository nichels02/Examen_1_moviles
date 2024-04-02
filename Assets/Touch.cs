using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    [SerializeField] Observador ElObservador;
    [SerializeField] float Profundidad;
    [SerializeField] float PosicionZReal;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            UnityEngine.Touch ElTouch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(ElTouch.position);
            Vector3 posicionDelTouch = ray.GetPoint(Profundidad);
            posicionDelTouch.z = PosicionZReal;
            ElObservador.transform.position= posicionDelTouch;

            

            if(ElTouch.phase == TouchPhase.Began)
            {
                
            }
        }
    }
}
