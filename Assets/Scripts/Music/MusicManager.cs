using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    [SerializeField]
    AudioSource[] sources;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (SceneManager.GetActiveScene().name != "Title")
        {
            for (int i = 0; i < sources.Length; i++)
            {
                if (!sources[i].isPlaying)
                {
                    sources[i].Play();
                }
            }
        }
    }
}
