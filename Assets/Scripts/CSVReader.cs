using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CSVReader : MonoBehaviour
{
    public GameObject inNoteObj;
    public AudioClip audioClip;
    public float pitchOfset = 0;
    int trackCount;
    string path;
    string[][] notedatas = new string[100000][];
    float time;
    int[] selector = new int[1000];
    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/midi2csv.txt";
        Debug.Log(path);
        string[] tracks = File.ReadAllText(path).Split('/');
        print(tracks[1]);
        int i = 0;
        trackCount = tracks.Length;
        foreach (string str in tracks)
        {
            notedatas[i] = str.Split('\n');
            i++;
        }
        print("trackCount:"+trackCount);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        for (int i = 0; i < trackCount-1; i++)
        {
            while (true)
            {
                if (selector[i] < notedatas.Length && notedatas[i][selector[i]] != "")
                {
                    string[] datas = notedatas[i][selector[i]].Split(' ');
                    if (float.Parse(datas[0]) < time)
                    {
                        float pitch = Mathf.Pow(2, (float.Parse(datas[2]) - pitchOfset) / 12);
                        GameObject noteObj = Instantiate(inNoteObj) as GameObject;
                        noteObj.GetComponent<noteManager>().Setup(audioClip, pitch, float.Parse(datas[1]) - float.Parse(datas[0]));
                        print("playAt:" + i + ":" + selector[i]);
                        print("pitch:" + pitch);
                        selector[i]++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
