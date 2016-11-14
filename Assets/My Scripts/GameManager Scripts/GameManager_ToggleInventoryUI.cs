using UnityEngine;
using System.Collections;

namespace S3
{
    public class GameManager_ToggleInventoryUI : MonoBehaviour
    {
        [Tooltip("Does this game mode have an inventory? Set to true if that is the case")]
        public bool hasInventory;
        public GameObject inventoryUI;
        public string toggleInventoryButton;
        private GameManager_Master gameManagerMaster;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForInventoryUIToggleRequest();
        }

        void SetInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();

            if (toggleInventoryButton == "")
            { 
                Debug.LogWarning("Please type in the name of the button used to toggle the inventory in " +
                    "GameManager_ToggleInventoryUI");
                this.enabled = false;
            }
        }

        void CheckForInventoryUIToggleRequest()
        { // we can set the inventory button 
            if (Input.GetButtonUp(toggleInventoryButton) && !gameManagerMaster.isMenuOn &&
				!gameManagerMaster.isGameOver && hasInventory) // if the inventory button pressed, and the game has an inventory (and game menu and game itself on)
            {
                ToggleInventoryUI();
            }
        }

		// all the pausing, freeing screen will happen automatically 
        public void ToggleInventoryUI() 
        {
            if (inventoryUI != null)
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf); // set the Inventory to the opposite of whatever state is in
                gameManagerMaster.isInventoryUIOn = !gameManagerMaster.isInventoryUIOn;
                gameManagerMaster.CallEventInventoryUIToggle();
            }
        }
    }
}


