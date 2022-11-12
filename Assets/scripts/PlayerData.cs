using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int altin;
    public int sopa;
    public float highscore;
    public bool[] Costumes;

    public PlayerData (e_information player, wayPoinText score)
    {
        altin = player.parasayisi;
        sopa = player.sopaCount;

        Costumes = new bool[11];
        Costumes[0] = player.costumes[0];
        Costumes[1] = player.costumes[1];
        Costumes[2] = player.costumes[2];
        Costumes[3] = player.costumes[3];
        Costumes[4] = player.costumes[4];
        Costumes[5] = player.costumes[5];
        Costumes[6] = player.costumes[6];
        Costumes[7] = player.costumes[7];
        Costumes[8] = player.costumes[8];
        Costumes[9] = player.costumes[9];
        Costumes[10] = player.costumes[10];

        highscore = score.highscore;
    }
}
