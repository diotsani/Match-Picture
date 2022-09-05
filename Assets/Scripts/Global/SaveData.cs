using System.Collections;
using UnityEngine;

namespace MatchPicture.Global
{
    public class SaveData : MonoBehaviour
    {
        public static SaveData saveDataInstance;
        private const string _prefsKey = "SaveData";

        private void Awake()
        {
            if(saveDataInstance == null)
            {
                saveDataInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            Load();
        }
        void Save()
        {
            string json = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(_prefsKey, json);
            Debug.Log(json);
        }
        void Load()
        {
            if (PlayerPrefs.HasKey(_prefsKey))
            {
                string json = PlayerPrefs.GetString(_prefsKey);
                JsonUtility.FromJsonOverwrite(json, this);
            }
        }
    }
}