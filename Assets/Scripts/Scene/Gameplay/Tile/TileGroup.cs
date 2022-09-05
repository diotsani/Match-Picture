using MatchPicture.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.Gameplay.Tile
{
    public class TileGroup : MonoBehaviour
    {

        [SerializeField] private TileObject _tilePrefab;

        [SerializeField] private List<TileObject> _listTile;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private List<Sprite> _listSprites;

        [SerializeField] private Camera _camera;
        private int _row = 6;
        private int _column = 5;
        private void Awake()
        {
            _sprites = ThemeDatabase.themeDataInstance.themeSprites;
            _listTile = new List<TileObject>();
            _listSprites = new List<Sprite>();
            CreateTile();
        }
        private void Start()
        {
            AddSprites();
        }
        void CreateTile()
        {
            for (int x = 0; x < _column; x++)
            {
                for (int y = 0; y < _row; y++)
                {
                    TileObject tile = Instantiate(_tilePrefab, transform);
                    _listTile.Add(tile);
                    tile.transform.position = new Vector2(x, y);
                }
            }
            _camera.transform.position = new Vector3(_column / 2, _row / 2, -10f);
        }

        void AddSprites()
        {
            int looper = _listTile.Count;
            int index = 0; 
            for (int i = 0; i < looper; i++)
            {
                if(index == looper/2) // error
                {
                    index = 0;
                }
                _listSprites.Add(_sprites[index]);
                index++;
            }
        }

    }
}