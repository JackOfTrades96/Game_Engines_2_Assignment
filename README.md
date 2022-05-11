# Game_Engines_2_Assignment

Name: Jack Mckenna
Student Number: C19744931

Class Group: DT508 Game Design


# Description of the project

[Watch  Video here]()

# Events Summary
1. Camera Switch between Fleet as they approach enemy.
2. When all ships arrive at their Arrive Points, GameManager begins Attack.
3. Federation Fighters Move towards enemy ships and they attack each other.
# How it works
I used Unity Events to carry each step. The Triggers where used to iniate the stages and from there,  each ship was given a newBehaiour.If any enemies came into range ships would  swicth to attacking and reterating states.

# Design
- ***Obstacle Avoidance***: Avoids game objects with a specific layer mask
- ***FighterCombatController***: Controls all commbat for each ship.
- ***ShipSquad***: Organises Fighter into squadrosn where they follow leader and follow his state behaviour.
-  - ***Obstacle Avoidance***:
- ***Trigger & Trigger Manager***: Used to Initae each event of the GameManager.
- ***CameraPointManager***: Used to switch the camera  beetween point in the world and follow ships.
 

# List of classes/assets with sources
| Class | Source |
|-----------|-----------|
|Arrive.cs|Modified from the module git|
|CameraPointManager.cs|Self-written|
|Explosion.cs|Self-written|
|FighterCombatController.cs|Self-written|
|Flee.cs|Modified from the module git|
|Follow.cs|Modified from the module git|
|GameManager.cs  |Self-written|
|ObstacleAvoidance.cs|Modified from the module git|
|OffsetPursue.cs|Modified from the module git|
|Phaser.cs|Self-written|
|Pursue.cs|Modified from the module git|
|Seek.cs|Modified from the module git|
|ShipCombatController.cs|Modified from the module git|
|ShipController.cs|Modified from the module git|
|ShipPath.cs|Modified from the module git|
|ShipSquad.cs|Self-written|
|StateMachine.cs|Modified from the module git|
|StateManager.cs|Self-written|
|States.cs|Modified from the module git|
|SteeringBehaviour.cs|Modified from the module git|
|Trigger.cs|Self-written|
|TriggerManager.cs|Self-written|




| Asset | Source |
|-----------|-----------|
|Defiant Model|https://www.trekmeshes.ch/meshes/meshesdual.php?DS=DS&MAX=MAX&LWO=LWO&COB=COB&Federation=Federation&Romulan=---&Klingon=---&Borg=---&Jemhadar=---&Cardassian=---&Others=---&Ship=Ship&Noncanon=---&Station=---&Shuttle=---&Other=---&SearchDay=0&SearchMonth=0&SearchYear=0&SearchWord=&Item=30&Zoomin=1&ZoomItem=DEFIANT|
|Galaxy Model|https://sketchfab.com/3d-models/uss-enterprise-d-star-trek-tng-e3118c97914342b3ad7dd957c4b4ce4e|
|Nebula  Model|https://www.trekmeshes.ch/meshes/meshesdual.php?DS=DS&MAX=MAX&LWO=LWO&COB=COB&Federation=Federation&Romulan=---&Klingon=---&Borg=---&Jemhadar=---&Cardassian=---&Others=---&Ship=Ship&Noncanon=---&Station=---&Shuttle=---&Other=---&SearchDay=0&SearchMonth=0&SearchYear=0&SearchWord=&Item=15&Zoomin=1&ZoomItem=NEBULA|
|SaberClass Model|https://www.trekmeshes.ch/meshes/meshesdual.php?DS=DS&MAX=MAX&LWO=LWO&COB=COB&Federation=Federation&Romulan=---&Klingon=---&Borg=---&Jemhadar=---&Cardassian=---&Others=---&Ship=Ship&Noncanon=---&Station=---&Shuttle=---&Other=---&SearchDay=0&SearchMonth=0&SearchYear=0&SearchWord=&Item=25&Zoomin=1&ZoomItem=SABER|
|SteamRunner Model|https://www.trekmeshes.ch/meshes/meshesdual.php?DS=DS&MAX=MAX&LWO=LWO&COB=COB&Federation=Federation&Romulan=---&Klingon=---&Borg=---&Jemhadar=---&Cardassian=---&Others=---&Ship=Ship&Noncanon=---&Station=---&Shuttle=---&Other=---&SearchDay=0&SearchMonth=0&SearchYear=0&SearchWord=&Item=25&Zoomin=1&ZoomItem=STEAMRUNNER|
|Norway Model|https://www.trekmeshes.ch/meshes/meshesdual.php?DS=DS&MAX=MAX&LWO=LWO&COB=COB&Federation=Federation&Romulan=---&Klingon=---&Borg=---&Jemhadar=---&Cardassian=---&Others=---&Ship=Ship&Noncanon=---&Station=---&Shuttle=---&Other=---&SearchDay=0&SearchMonth=0&SearchYear=0&SearchWord=&Item=65&Zoomin=1&ZoomItem=EDVOYAGER|
| Federation Attack Fighter Model|https://sketchfab.com/3d-models/federation-attack-fighter-e8a4ee7b6a7d43218bfad55b64030ff0|
|Akira Model|https://sketchfab.com/3d-models/akira-ad318bdd1d44429e88ca7245006fe2e9|
|Galor Model|https://www.trekmeshes.ch/meshes/meshesdual.php?DS=DS&MAX=MAX&LWO=LWO&COB=COB&Federation=Federation&Romulan=Romulan&Klingon=Klingon&Borg=Borg&Jemhadar=Jemhadar&Cardassian=Cardassian&Others=Others&Ship=Ship&Noncanon=Noncanon&Station=Station&Shuttle=Shuttle&Other=Other&SearchDay=0&SearchMonth=0&SearchYear=0&SearchWord=&Item=5&Zoomin=1&ZoomItem=GALORRICK|
|Hideki Model| https://www.trekmeshes.ch/meshes/meshesdual.php?DS=DS&MAX=MAX&LWO=LWO&COB=COB&Federation=Federation&Romulan=Romulan&Klingon=Klingon&Borg=Borg&Jemhadar=Jemhadar&Cardassian=Cardassian&Others=Others&Ship=Ship&Noncanon=Noncanon&Station=Station&Shuttle=Shuttle&Other=Other&SearchDay=0&SearchMonth=0&SearchYear=0&SearchWord=&Item=10&Zoomin=1&ZoomItem=HEDEKI2|
|Jem'Hadar BattleCrusier Model|https://www.trekmeshes.ch/meshes/meshesdual.php?DS=DS&MAX=MAX&LWO=LWO&COB=COB&Federation=---&Romulan=---&Klingon=---&Borg=---&Jemhadar=Jemhadar&Cardassian=Cardassian&Others=---&Ship=Ship&Noncanon=---&Station=Station&Shuttle=Shuttle&Other=Other&SearchDay=0&SearchMonth=0&SearchYear=0&SearchWord=&Item=5&Zoomin=1&ZoomItem=DOMINIONBATTLESHIP|
|Jem'Hadar Fighter Model| https://sketchfab.com/search?q=Jem&type=models|
|Explosion||  
