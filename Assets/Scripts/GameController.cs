using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{

    public int collectable = 0;
    public TextMeshProUGUI txt;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        txt.text = collectable.ToString();
    }
}
