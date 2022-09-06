using MatchPicture.Gameplay.Inputs;
using System.Collections;
using UnityEngine;

namespace MatchPicture.Gameplay.Tile
{
    public class TileObject : MonoBehaviour, IRaycastable
    {
        [SerializeField] private Sprite _tileSprite;
        [SerializeField] private SpriteRenderer _childSprite;
        [SerializeField] private string _nameSprite;
        [SerializeField] private TileGroup _tileGroup;

        public void InitTileGroup(TileGroup tileGroup)
        {
            _tileGroup = tileGroup;
        }

       public void ChangeSprite(Sprite sprite)
        {
            _tileSprite = sprite;
        }
        public void OnRaycasted()
        {
            OnChangeSprite();
            //Debug.Log(gameObject.transform.name);
        }

        void OnChangeSprite()
        {
            _childSprite.gameObject.SetActive(true);
            _childSprite.sprite = _tileSprite;

            _nameSprite = _childSprite.sprite.name;
            _tileGroup.CheckMatch(_nameSprite, this);

            //if (_tileGroup.firstCheck == null)
            //{
            //    _tileGroup.firstCheck = _nameSprite;
            //}
            //else
            //{
            //    _tileGroup.secondCheck = _nameSprite;
            //    _tileGroup.CheckMatch(_nameSprite);
            //}
            
            //this.transform.GetChild(0).gameObject.SetActive(true);
            //this.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = _tileSprite;
        }
    }
}