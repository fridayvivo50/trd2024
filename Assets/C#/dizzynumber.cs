using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dizzynumber : MonoBehaviour
{
    private string UItext = "";
    public Player player;
    public TMPro.TextMeshProUGUI dizzy;
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        number = player.confusionLevel;
        UItext = string.Format("{0}", player.confusionLevel);
        dizzy.text = UItext;
    }

    // Update is called once per frame
    void Update()
    {
        number = player.confusionLevel;
        UItext = string.Format("{0}", player.confusionLevel);
        dizzy.text = UItext;
    }
}
