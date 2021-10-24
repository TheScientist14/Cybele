using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutoScript : MonoBehaviour
{
    public GameObject[] dialogues;
    // Start is called before the first frame update
    void Start()
    {
        runTuto();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void runTuto()
    {
        GameManager.instance.SpawnProcession();

        GameManager.instance.EndTuto();
        SceneManager.LoadScene(2);
    }
}
