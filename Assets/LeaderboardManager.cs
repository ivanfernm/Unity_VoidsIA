using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager instance;
    public List<PlayerScore> leaderboard = new List<PlayerScore>();
    [Range(0, 20)] public int maxleaderboardentries = 10;

    private void Awake()
    {
        if (LeaderboardManager.instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(string playerName, int score)
    {
        leaderboard.Add(new PlayerScore { playerName = playerName, score = score });
        SortLeaderboard();
        Trimleaderboard();
    }

    private void SortLeaderboard() => leaderboard = leaderboard.OrderByDescending(x => x.score).ToList();

    private void Trimleaderboard()
    {
        if (leaderboard.Count > maxleaderboardentries) leaderboard.GetRange(0, maxleaderboardentries);
    }
    
    public void DisplayLeaderboard()
    {
        foreach (var entry in leaderboard)
        {
            Debug.Log($"{entry.playerName}: {entry.score}");
        }
    }
}


//clase que va a handelear el score
[System.Serializable]
public class PlayerScore
{
    public string playerName;
    public int score;
}