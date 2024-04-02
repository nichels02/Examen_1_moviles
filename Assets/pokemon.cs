using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Estados
{
    idle,
    ataque
}


public class pokemon : MonoBehaviour
{
    [SerializeField] Estados ElEstado = Estados.idle;
    [SerializeField] float tiempo;
    [SerializeField] float DuracionDeIdle;
    [SerializeField] float DuracionDeAtaques;
    [SerializeField] float tiempoMax;
    [SerializeField] float tiempoMin;
    bool CalcularTiempo = true;
    MeshRenderer MyMeshRenderer;


    // Start is called before the first frame update
    void Start()
    {
        MyMeshRenderer = GetComponent<MeshRenderer>();
        MyMeshRenderer.material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if (ElEstado == Estados.idle)
        {
            if (CalcularTiempo)
            {
                CalcularTiempo = false;
                DuracionDeIdle = Random.Range(tiempoMin, tiempoMax);
            }
            if(tiempo < DuracionDeIdle)
            {
                tiempo += Time.deltaTime;
            }
            else
            {
                ElEstado = Estados.ataque;
                MyMeshRenderer.material.color = Color.red;
                tiempo = 0;
            }
        }
        else
        {
            if (tiempo < DuracionDeAtaques)
            {
                tiempo += Time.deltaTime;
            }
            else
            {
                ElEstado = Estados.idle;
                MyMeshRenderer.material.color = Color.blue;
                tiempo = 0;
                CalcularTiempo = true;
            }
        }
    }
}
