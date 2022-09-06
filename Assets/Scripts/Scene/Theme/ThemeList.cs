using MatchPicture.Global;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MatchPicture.Theme
{
    public class ThemeList : MonoBehaviour
    {
        [SerializeField] private Button _themePrefabs;
        [SerializeField] private Transform _themeParent;
        [SerializeField] private List<Button> _themeObjects;
        [SerializeField] private string _selectedTheme;


        private void Start()
        {
            _themeObjects = new List<Button>();

            ThemeData[] themeDatas = (ThemeData[])Enum.GetValues(typeof(ThemeData));
            for (int i = 0; i < themeDatas.Length; i++)
            {
                Button themeButton = Instantiate(_themePrefabs, _themeParent) as Button;
                _themeObjects.Add(themeButton);

                ThemeData themeType = themeDatas[i];
                themeButton.name = themeType.ToString();
                themeButton.GetComponentInChildren<TMP_Text>().text = themeType.ToString();
                themeButton.onClick.AddListener(delegate () { OnClickTheme(themeType,themeButton); });
            }
        }

        private void Update()
        {
            
            
        }

        void OnClickTheme(ThemeData themeDatas, Button button)
        {
            ActivatedChecklist();
            button.transform.GetChild(0).gameObject.SetActive(true);

            ThemeDatabase.themeDataInstance.themeData = themeDatas;
            ThemeDatabase.themeDataInstance.ChangeThemeData();
        }

        void ActivatedChecklist()
        {
            for (int i = 0; i < _themeObjects.Count; i++)
            {
                _themeObjects[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}