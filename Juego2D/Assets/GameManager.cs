using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton para acceder a la instancia desde otros scripts.

    private int puntosTotales = 0;
    public int vidasTotales = 3; // Suponiendo un máximo de 3 vidas para empezar.

    public HUD hud; // Referencia al script HUD.


    public ScoreHUD scoreHUD;

    public int PuntosTotales
    {
        get { return puntosTotales; }
        set
        {
            puntosTotales = value;
            scoreHUD.UpdateScore(puntosTotales); // Actualiza el HUD cuando cambian los puntos
        }
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Opcional: Hace que el GameManager persista entre escenas.
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RecogerMoneda(int puntos)
    {
        PuntosTotales += puntos; // Añade puntos y actualiza el HUD automáticamente.
    }

    public bool RecuperarVida()
    {
        if (vidasTotales < 3) // Asegúrate de tener un máximo de vidas.
        {
            vidasTotales++;
            hud.ActivarVida(vidasTotales - 1); // Activar la vida correspondiente en el HUD.
            return true;
        }
        return false;
    }

    public void PerderVida()
    {
        if (vidasTotales > 0)
        {
            vidasTotales--;
            hud.DesactivarVida(vidasTotales); // Desactivar la vida correspondiente en el HUD.

            if (vidasTotales <= 0)
            {
                // Aquí puedes manejar lo que sucede cuando el jugador pierde todas sus vidas.
                Debug.Log("Juego Terminado");
            }
        }
    }
   
}