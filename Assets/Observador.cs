using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Observador : MonoBehaviour
{
    [SerializeField] float distancia;
    [SerializeField] Vector3 direccion;
    [SerializeField] LayerMask ElLayer;
    RaycastHit LaColicion;

    public GameObject ElObjeto;

    private void Update()
    {
        if (Physics.Raycast(transform.position, direccion, out LaColicion, distancia, ElLayer))
        {
            // Se ha encontrado una colisión
            ElObjeto = LaColicion.collider.gameObject;

        }
        else
        {
            ElObjeto = null;
        }
    }


    private void OnDrawGizmos()
    {
        // Dibujar el raycast en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, direccion * distancia);
    }


}
