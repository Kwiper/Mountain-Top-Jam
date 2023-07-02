using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeathText : MonoBehaviour
{
    TextMeshProUGUI text;

    [SerializeField]
    PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Total Deaths: " + playerData.deaths;
    }
}
