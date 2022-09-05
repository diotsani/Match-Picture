using MatchPicture.Global;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MatchPicture.Home
{
    public class HomeScene : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _themeButton;

        private void Awake()
        {
            _playButton.onClick.AddListener(OpenGameplay);
            _themeButton.onClick.AddListener(OpenTheme);
        }
        void OpenGameplay()
        {
            SceneManager.LoadScene("Gameplay");
            ThemeDatabase.themeDataInstance.SetThemeData();
        }
        void OpenTheme()
        {
            SceneManager.LoadScene("Theme");
        }
    }
}