using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPlayer: MonoBehaviour
{
    public TextMesh myLife;

    public void RepaintLife(int life)
    {
        myLife.text = life.ToString();
    }
}
