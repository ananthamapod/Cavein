# Preliminary Design Document
## Unit class

### Characteristics

* Movement speed as defined by the amount of tiles the unit can move in a single turn regardless of angling
* HP as defined by a set number
* Attack range as defined by the amount of tiles and the direction of tiles an unit can attack in
* Attack damage as defined by the amount of HP taken away from unit within attack range during attack
* Weapon object
* Upgrades as defined by a modifier of the above or the weapon class in some way.

###	Unit sub-classes (role class)

*	Scout- Fast speed, low hp, no damage attack, can blind a unit for 1 turn (turns attack range of 	enemy to 0 for 1 turn).

*	Sniper -  Medium movement, low hp, long range vision. Can shoot only in a straight line. 	Option for any enemy unit crossing the path to be automatically shot. Needs a turn to reload.

*	Assassin – Close range, low hp, fast speed, high attack damage. Undetected attack from behinds 	are an automatic kill on any unit.

*	Solider – Decent everything. Mid range attack range, damage, speed and hp.

*	Technician- Above average speed, below average hp, weak attack. Can set and disarm traps. Can test traps.

*	Terraformer – Can create and destroy terrain. Low hp, close range attack, low speed, low damage attack.

*	Tank – Low move speed, high hp, medium attack damage, low range.

*	Shotgun Bitch- AOE attack, close range, average move speed, high armor.

*	Meat shield- No attack, high speed, dies in 1 hit, upon death guts explode releasing a biomass posion which damages and blinds ALL units in a square radius around it.


## Weapons class

* Weapon skin
* Bullet particle

## Ability class


## Upgrade class

>Object types that modify the stat of units and subclasses.

## Network Design
* Update function of the game controller just checks for flags from player scripts that handles user input and sets a flag when user has submitted their move. 

## Game Controller class

Top level controller that manages the overall game.

Contains references to:
* List of players
* Board
* Game status

## GameBoard class

Contains graph of tiles
Generates board obstacles (helper class RandomizedMap)

Game Mechanics

Priority of Moves

1. Melee
2. Shooting
3. Movement

If 2 units move to the same tile they will push each other back to the last tile they were on and both units will have melee damage inflicted to each other. 

