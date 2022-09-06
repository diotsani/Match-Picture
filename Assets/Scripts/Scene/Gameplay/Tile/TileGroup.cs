using MatchPicture.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.Gameplay.Tile
{
    public class TileGroup : MonoBehaviour
    {

        [SerializeField] private TileObject _tilePrefab;
        [SerializeField] private Sprite[] spriteRenderer;

        [SerializeField] private List<TileObject> _listTile;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private List<Sprite> _listSprites;
        [SerializeField] private int _firstIndex;

        [SerializeField] private Camera _camera;
        private int _row = 6;
        private int _column = 5;

        private void Awake()
        {
            _sprites = ThemeDatabase.themeDataInstance.themeSprites;
            _listTile = new List<TileObject>();
            _listSprites = new List<Sprite>();

            AddSprites();
            CreateTile();
            Shuffle(_listSprites);
        }
        private void Start()
        {
            
        }
        private void Update()
        {
            OnMouseClick();
        }
        void CreateTile()
        {
            int maxTile = _column * _row;
            for (int x = 0; x < _column; x++)
            {
                for (int y = 0; y < _row; y++)
                {
                    
                    TileObject tile = Instantiate(_tilePrefab, transform);
                    
                    _listTile.Add(tile);
                    tile.transform.position = new Vector2(x, y);

                    int indexName = _listTile.Count-1;
                    tile.transform.name = "" + indexName;

                    
                    //indexName++;
                }
            }
            _camera.transform.position = new Vector3(_column / 2, _row / 2, -10f);
        }

        void AddSprites()
        {
            int looper = _row * _column;
            if (looper % 2 != 0 || looper < 2) return;

            for (int i = 0; i < looper/2; i++)
            {
                Sprite randomSpites = GetRandomSprite(_sprites);
                for (int j = 0; j < 2; j++)
                {
                    Sprite addSprite = randomSpites;
                    
                    _listSprites.Add(addSprite);
                }
            }
        }
        Sprite GetRandomSprite(Sprite[] sprites)
        {
            return sprites[Random.Range(0,sprites.Length)];
        }
        void Shuffle(List<Sprite> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Sprite temp = list[i];
                int randomIndex = Random.Range(i, list.Count);
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
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
                    Debug.Log(hit.collider.gameObject.name);
                    ClickedSprite(hit);
                    
                }
            }
            
        }
        void ClickedSprite(RaycastHit2D hit2d)
        {
            string name = hit2d.transform.name;
            _firstIndex = int.Parse(name);
            
            //_listTile[_firstIndex].GetComponent<SpriteRenderer>().sprite = _listSprites[_firstIndex];
            _listTile[_firstIndex].transform.GetChild(0).gameObject.SetActive(true);
            _listTile[_firstIndex].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = _listSprites[_firstIndex];
        }

    }
}