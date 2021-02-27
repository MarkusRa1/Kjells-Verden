using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }

    public void SetTekst(string tekst) {
        //gameObject.GetComponent<Text>().text = tekst;
        gameObject.SetActive(true);
    }

    void Update()
    {
        gameObject.GetComponent<Text>().text = Time.realtimeSinceStartup.ToString();
    }
}
