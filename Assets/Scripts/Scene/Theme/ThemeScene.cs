using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts.Theme
{
    public class ThemeScene : MonoBehaviour
    {

        [SerializeField] private Button _backButton;
        [SerializeField] private TMP_Text _currencyText;

        private void Awake()
        {
            _backButton.onClick.AddListener(BackHome);
        }
        void BackHome()
        {
            SceneManager.LoadScene("Home");
        }
    }
}