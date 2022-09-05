using System.Collections;
using UnityEngine;

namespace MatchPicture.Global
{
    public class ThemeDatabase : MonoBehaviour
    {
        public static ThemeDatabase themeDataInstance;

        public ThemeData themeData;
        [SerializeField] private string themeName;

        public Sprite[] themeSprites;

        private void Awake()
        {
            if (themeDataInstance == null)
            {
                themeDataInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            themeName = themeData.ToString();
        }
        public void ChangeThemeData()
        {
            themeName = themeData.ToString();
        }

        public void SetThemeData()
        {
            themeSprites = Resources.LoadAll<Sprite>("Sprites/" + themeName);
        }
    }
    public enum ThemeData
    {
        Fruit,
        Food,
        Weapon,
        Random
    }
}