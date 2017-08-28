using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper3D
{
    [RequireComponent(typeof(Renderer))]
    public class Block : MonoBehaviour
    {
        public int x, y, z;
        public bool isMine = false;
        [Header("References")]
        public Color[] textColors;
        public TextMesh textElement;
        public Transform mine;

        private bool isRevealed = false;
        private Renderer rend;

        void Awake()
        {
            rend = GetComponent<Renderer>();
        }

        // Use this for initialization
        void Start()
        {
            // Detach text element from the block
            textElement.transform.SetParent(null);
            // Randomly decide if it's a mine or not
            isMine = Random.value < 0.5f;
        }

        void UpdateText(int adjacentMines)
        {
            // Are there adjacent mines?
            if(adjacentMines > 0)
            {
                // Set text to amount of mines
                textElement.text = adjacentMines.ToString();

                // Check if adjacentMines are within textColor's array
                if(adjacentMines >= 0 && adjacentMines < textColors.Length)
                {
                    // Set text color to whatever was preset
                    textElement.color = textColors[adjacentMines];
                }
            }
        }

        public void Reveal(int adjacentMines)
        {
            // Flag the block being revealed
            isRevealed = true;
            // IF block is a mine
            if(isMine)
            {
                // Activates the mine
                mine.gameObject.SetActive(true);
                // Detach it from children
                mine.SetParent(null); // ... I'm Batman
            }
            else
            {
                // Updates the text to display adjacentMines
                UpdateText(adjacentMines);
            }

            // Deactivates the block
            gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
