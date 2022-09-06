using MatchPicture.Gameplay.Inputs;
using System.Collections;
using UnityEngine;

namespace MatchPicture.Gameplay.Inputs
{
    public class InputRaycast : MonoBehaviour
    {
        private void Update()
        {
            RaycastObject();
        }
        void RaycastObject()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(world, Vector2.zero);

                if (hit.collider != null)
                {
                    IRaycastable raycastedObj = hit.collider.GetComponent<IRaycastable>();
                    raycastedObj?.OnRaycasted();
                }
            }
        }
    }
}