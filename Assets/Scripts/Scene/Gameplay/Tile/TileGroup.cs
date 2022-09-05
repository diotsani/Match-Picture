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
        [SerializeField] private int _firstIndex;

        [SerializeField] private Camera _camera;
        private int _row = 6;
        private int _column = 4;

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
        private void Update()
        {
            OnMouseClick();
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

                    int indexName = _listTile.Count;
                    tile.transform.name = "" + indexName;
                    indexName++;
                }
            }
            _camera.transform.position = new Vector3(_column / 2, _row / 2, -10f);
        }

        void AddSprites()
        {
            int looper = _listTile.Count;
            if (looper % 2 != 0 || looper < 2) return;

            Sprite[] sp = _sprites;
            for (int i = 0; i < looper/2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int index = i;
                    _listSprites.Add(sp[index]);
                }

                
                //if(index == looper / 2) // error
                //{
                //    index = 0;
                //}
                //_listSprites.Add(_sprites[index]);
                //index++;
            }
        }
        private void OnMouseClick()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(world, Vector2.zero);

                if (hit.collider != null)
                {
                    ClickedSprite(hit);
                    
                }
            }
            
        }
        void ClickedSprite(RaycastHit2D hit2d)
        {
            string name = hit2d.transform.name;
            _firstIndex = int.Parse(name);
            _listTile[_firstIndex].GetComponent<SpriteRenderer>().sprite = _listSprites[_firstIndex];

            Debug.Log("clicked");
        }

    }
}