using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class GameData
{
    // this is being written for json NOT c#
    [Serializable]
    public class UnlockedCharacter
    {
        public string Name = "";
        public bool IsUnlocked = false;
    }
    public float FastestTime = 0.0f;
    public int TimesPlayed = 0;
    public List<float> TopFiveTimes = new List<float>();
    public List<UnlockedCharacter> UnlockedCharacters = new List<UnlockedCharacter>();
}
