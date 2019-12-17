﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private List<Tuple<int, string>> leaderboard;

    private void Start()
    {
        if (PlayerPrefs.HasKey("leaderboard"))
        {
            foreach (string s in PlayerPrefs.GetString("leaderboard").Split('|'))
            {
                string[] elems = s.Split(';');
                leaderboard.Add(new Tuple<int, string>(int.Parse(elems[0]), elems[1]));
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                leaderboard.Add(new Tuple<int, string>(0, "None"));
            }
        }
    }

    public void AddScore(int score, string name)
    {
        name = name.Replace(";", "").Replace("|", "");
        int playerIndex = -1;
        for (int i = 0; i < leaderboard.Count; i++)
        {
            if (leaderboard[i].Item1 < score)
            {
                playerIndex = i;
                break;
            }
        }
        if (playerIndex != -1)
        {
            for (int i = leaderboard.Count - 1; i >= 0; i--)
            {
                if (playerIndex == i)
                {
                    leaderboard[i] = new Tuple<int, string>(score, name);
                    break;
                }
                else
                {
                    leaderboard[i] = leaderboard[i - 1];
                }
            }
            PlayerPrefs.SetString("leaderboard", string.Join("|", leaderboard.Select(x => x.Item1 + ";" + x.Item2)));
            PlayerPrefs.Save();
        }
    }

    public List<Tuple<int, string>> GetLeaderboard()
        => leaderboard;
}