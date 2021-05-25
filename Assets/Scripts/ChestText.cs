using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestText : MonoBehaviour
{

    [SerializeField] private GameObject chestUI;
    [SerializeField] private GameObject endUI;

    // Start is called before the first frame update
    void Start()
    {
        chestUI.SetActive(false);
    }

}
