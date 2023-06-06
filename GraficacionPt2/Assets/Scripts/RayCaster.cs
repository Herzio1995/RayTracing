using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private Vector3 origenRayo = new(0.0f, -6f, 1f);
    private Vector3 direccionRayo = new(-0.5f, -4.6f, 1.27f);
    [SerializeField] private Vector3 centroEsfera = new(0f, 0f, 1f);
    [SerializeField] private float radioEsfera = 1.0f;
    [SerializeField] private int resAncho = 32;
    [SerializeField] private int resAlto = 24;
    [SerializeField] private GameObject pixelEsfera;
    [SerializeField] private GameObject pixel;
    //0.03125
    //0.02375

    private void Start()
    {
        //Debug.Log(intersectaEsfera());
        for (int i = 0; i < resAlto; i++) {
            for (int j = 0; j < resAncho; j++) {
                if (intersectaEsfera(direccionRayo))
                {
                    Instantiate(pixelEsfera, new Vector3(j, i, 0), Quaternion.identity);
                }
                else {
                    Instantiate(pixel, new Vector3(j, i, 0), Quaternion.identity);
                }
                direccionRayo.x += 0.0312f;
            }
            direccionRayo.x = -0.5f;
            direccionRayo.z -= 0.02375f;
        }
        Debug.Log(direccionRayo);

    }
    public bool intersectaEsfera(Vector3 direccionRayoAux)
    {
        float A = direccionRayoAux.x * direccionRayoAux.x + direccionRayoAux.y * direccionRayoAux.y
                + direccionRayoAux.z * direccionRayoAux.z;

        float B = 2 * (direccionRayoAux.x * (origenRayo.x - centroEsfera.x)
                + direccionRayoAux.y * (origenRayo.y - centroEsfera.y)
                + direccionRayoAux.z * (origenRayo.z - centroEsfera.z));

        float C = (origenRayo.x - centroEsfera.x) * (origenRayo.x - centroEsfera.x)
                + (origenRayo.y - centroEsfera.y) * (origenRayo.y - centroEsfera.y)
                + (origenRayo.z - centroEsfera.z) * (origenRayo.z - centroEsfera.z)
                - radioEsfera * radioEsfera;

        float discriminante = B * B - 4 * A * C;

        if (discriminante < 0)
        {//no
            return false;
        }
        else if (discriminante == 0)
        {//si
            return true;
        }
        else
        {//si pero en 2
            return true;
        }
    }
}