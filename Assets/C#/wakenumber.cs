using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wakenumber : MonoBehaviour
{
    private string UItext = "";
    public Player player;
    public TMPro.TextMeshProUGUI wake;
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        number = player.clarityLevel;
        UItext = string.Format("{0}", player.clarityLevel);
        wake.text = UItext;
    }

    // Update is called once per frame
    void Update()
    {
        number = player.clarityLevel;
        UItext = string.Format("{0}", player.clarityLevel);
        wake.text = UItext;
    }
}
