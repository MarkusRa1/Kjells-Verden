using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class Taper : MonoBehaviour
{
    public GameObject TextObj;
    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
        gameObject.SetActive(false);
    }


    public void GameOver(float TimeSinceStartup)
    {
        gameObject.SetActive(true);
        TextObj.GetComponent<GameOverTid>().SetTekst(TimeSinceStartup.ToString());
    }

}
