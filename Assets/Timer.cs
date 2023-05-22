using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   [SerializeField] TMP_Text TextTimer;
   public float Waktu = 100;
   public bool GameAktif = true;
   public GameObject FinishedCanvas;

   public void SetText()
   {
        int Menit = Mathf.FloorToInt(Waktu / 60);
        int Detik = Mathf.FloorToInt(Waktu % 60);
        TextTimer.text = Menit.ToString("00") + ":" + Detik.ToString("00");
   }

   float s;

   private void Update() 
   {
        if(GameAktif)
        {
            s += Time.deltaTime;
            if(s >= 1)
            {
                Waktu--;
                s = 0;
            }
        }

        if(GameAktif && Waktu <= 0)
        {
            Debug.Log("GameOver");
            FinishedCanvas.SetActive(true);
            GameAktif = false;
        }

        SetText();
   }
}
