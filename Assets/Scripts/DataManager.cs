using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor.Experimental.RestService;


public class DataManager : MonoBehaviour
{

    private string _dataPath;

    private string _xmlMembers;
    private string _jsonMembers;

    private List<Members> memberList = new List<Members>()
    {
        new Members("Clara",1998,"Black"),
        new Members("Astrid",2003,"Orange"),
        new Members("Benjamin",1998,"Blue"),
        new Members("Oliver", 2001,"Purple"),
        new Members("Christoffer",2002,"Yellow")
    };
    // Start is called before the first frame update
    void Awake()
    {
        _dataPath = Application.persistentDataPath + "/Player_Data/";
        Debug.Log(_dataPath);

        _xmlMembers = _dataPath + "MembersData.xml";
        _jsonMembers = _dataPath + "MembersData.json";
    }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        NewDirectory();
        SerializeXML();
        DeserializeXML();
        SerializeJSON();
    }

    public void NewDirectory()
    {
        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
            Debug.Log("Directory Created at: " + _dataPath);
        }
        else
        {
            Debug.LogWarning("Directory already exists at: " + _dataPath);
        }
    }

    public void SerializeXML()
    {
        var xmlserializer = new XmlSerializer(typeof(List<Members>));

        using (FileStream stream = File.Create(_xmlMembers))
        {
            xmlserializer.Serialize(stream, memberList);
        }
    }

    public void DeserializeXML()
    {
        if (File.Exists(_xmlMembers))
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Members>));

            using (FileStream stream = File.OpenRead(_xmlMembers))
            {
                var members = (List<Members>)xmlSerializer.Deserialize(stream);

                foreach (var Members in members)
                {
                    Debug.LogFormat(Members.name);
                    //Debug.LogFormat(Members.year);
                    Debug.LogFormat(Members.color);
                }
            }
        }
    }

    public void SerializeJSON()
    {
        Members.MemberList group = new Members.MemberList();
        group.list = memberList;

        string jsonString = JsonUtility.ToJson(group, true);

        using (StreamWriter stream = File.CreateText (_jsonMembers))
        {
            stream.WriteLine(jsonString);
        }
    }
}
