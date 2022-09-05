using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MatchPicture.Gameplay
{
    public class GameFlow : MonoBehaviour
    {

        [SerializeField] private Button _homeButton;

        [SerializeField] private GameObject _panelGameOver;
        [SerializeField] private TMP_Text _winText;
        [SerializeField] private TMP_Text _rewardText;

        private void Awake()
        {
            _homeButton.onClick.AddListener(BackHome);
        }
        void BackHome()
        {
            SceneManager.LoadScene("Home");
        }
    }
}