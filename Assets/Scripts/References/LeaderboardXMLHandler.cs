using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class LeaderboardXMLHandler : MonoBehaviour
{
    public Leaderboard leaderboard;

    public void SaveScores(List<PlayerScoreEntry> saveScores){
        leaderboard.list = saveScores;
        XmlSerializer serializer = new XmlSerializer(typeof(Leaderboard));
        if(!Directory.Exists(Application.persistentDataPath + "/LeaderBoard/")){
            Directory.CreateDirectory(Application.persistentDataPath + "/LeaderBoard/");
        }
        FileStream stream = new FileStream(Application.persistentDataPath + "/LeaderBoard/highscores.xml", FileMode.Create);
        serializer.Serialize(stream, leaderboard);
        stream.Close();
    }

    public List<PlayerScoreEntry> LoadScores(){
        if(File.Exists(Application.persistentDataPath + "/LeaderBoard/highscores.xml")){
            XmlSerializer serializer = new XmlSerializer(typeof(Leaderboard));
            FileStream stream = new FileStream(Application.persistentDataPath + "/LeaderBoard/highscores.xml", FileMode.Open);
            leaderboard = serializer.Deserialize(stream) as Leaderboard;
        }
        return leaderboard.list;
    }

    public static LeaderboardXMLHandler instance;
    void Awake(){
        instance = this;
    }
}
