Lethal company but worse.
In my version of the game, the player is spawned in the ship, from where they must find the entrance into the facility. 
Once the player has found the entrance and entered the facility, they can collect scrap and bring it back to the ship. 
Once the player spawns, 1 minute timer starts and when it’s out a creature is spawned in the facility, which will make it difficult for the player to collect the scrap. 
The player must collect all of the scrap to get the perfect score.

The main parts of the game are: 
Player and camera
-	The playable character is an astronaut that one can move by WSAD.
-	The camera is a child object of the player, one can look around with the mouse. 
-	The player can interact with objects such as buttons, ladders, doors and scrap by looking at them and pressing e.
Enemy 
-	The enemy I have intended to recreate is the Coil-Head, which behaves similar to a weeping angel. In my game the model of this enemy is a ghost.
Scrap 
-	Scrap is the objects one find in the facility and have to bring back to the ship. 
-	Scrap can be collected by looking at it and pressing e.
-	Scrap can be dropped by pressing g.
-	The player can hold up to 4 scrap items in their inventory.
-	When the scrap spawns, it gets a random price within a range defined for every scrap item.
-	As the player starts the ship to end the game, they will see how much scrap (cost of it) they have collected.

Project parts
1.	Enemy, creature navigation and spawning
   
There are four scripts used for the Coil-Head navigation, behavior and spawning: Creatures, CoilHeadScript, NodeScript and CreatureSpawner. 
The CreatureSpawner starts a timer of one minute in the beginning of the game, once it runs out an instance of the Coil-Head prefab is instantiated in the place of an empty game object inside the facility.
In the NodesScript, I create an array where I store all the 32 nodes that are placed on the map. Then I loop through these and save their position in the notVisitedNodes list. The list is used in the Creatures script.
The Creatures is a base class, where I define methods for movement (using the NavMesh Agent), dealing damage upon collision with the player, and patrolling. 
I use the list defined In the NodesScript to get all of their positions. I then iterate through all of these and find the one that is closest to the creature. 
The creature then navigates to that node and marks the previous one as previousNode (when the creature spawns, the previous node is set to the creatures position). 
Once the creature arrives at the node that was set as the destination, that node is removed from the nodes list. 
After that, the node that is closest to the previousNode is found among the remaining nodes in the list, and position of it is set to be the new destination. 
The CoilHeadScript is a subclass of the Creature class. In this class I implement a method, CheckIfVisible that specifies when the creature is allowed to move. 
I firstly make the Coil-Head cast a ray towards the player and save the information about the collider that was hit by the ray. 
To decide whether the Coil-Head is allowed to move I check whether it is outside of the cameras view port (!objectRenderer.isVisible). 
If the camera is not pointed at it, it is allowed to move. Then I check whether what was returned by the creatures raycast wasn’t the player, and if it indeed was not the player then it is allowed to move.
If both of these has returned false, that is – the player is looking and the creature is able to draw an uninterrupted ray towards the player, then the Coil-Head has to stop. 
The Coil-Head has a detection sphere with a radius of 8m, and when the player enters this area an inRange bool is set to true. 
If the player is within this range and is marked as found, then the chase behavior is started, where the creatures movement speed will be increased and it will move towards the players position. 
Upon collision with the player, the Coil-head will deal 90 damage.

2.  Player
   
The player has a PlayerScripty attached, and in it I have defined an event, that gets fired every time one presses e. The listeners of that event are all the objects the player can interact with within the game world.
The player has 100 health, and when the player gets killed, a restart screen will show up.

3.  Scrap system/ Inventory
   
The scrap/inventory system is built up of four main scripts: IPickableItem, PickUpSystem, InventoryHandler and Inventory.
Additionally, all the items the player can pick up have their own scripts that implements the IPickableItem interface.
Another related script is GroundCheck, which manages the items physics when these are on the ground. 
The Inventory class defines a list, that can contain up to four objects that have the IPickable interface implemented.
This interface specifies properties such as Name, Image and ScrapValue.  When an item is picked up, it is added to the inventory via the AddItem method, which disables the items rigidbody and collider and adds it to the list.
Besides, an event is envoked (ItemAdded), that makes the InventoryHandler script update the UI in response.
The items can also be removed from the inventory when the player drops them. When an item is dropped, it is removed from the list via the RemoveItem method and it's rigidbody and collider are re-enabled.
The rigidbody is reenabled as the player drops the item, but when the item touches the ground the rigidbody is constrained again in the GroundCheck script.
As an item is dropped, an event called ItemRemoved is envoken and the UI is updated. 
The PickUpSystem handles the pickup by making the item a child of the main camera and removing it again when the item is dropped.
Besides, in the same script the currently selected item is tracked through an objectIndex, and the player can switch the item by using the mouse wheel. The UI will be changed in response to that, as the item slot will increase in size. 

