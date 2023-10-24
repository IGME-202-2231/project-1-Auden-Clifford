# Project SPINNERSCORGE

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

### Student Info

-   Name: AUDEN CLIFFORD
-   Section: #02

## Game Design

-   Camera Orientation: topdown
-   Camera Movement: follows player
-   Player Health: healthpoints; equivalent to rotational velocity (you die when you stop spinning)
-   End Condition: game ends when the player dies; the object is to get as high a score as possible before that happens
-   Scoring: Killing enemies give you points towards your score; certain enemies reward more points

### Game Description

SPINNERSCORGE, beyblades with guns. In spinnerscorge, you play as a spinner/top and must survive as long as possible against other spinners. If you stop spinning your out of the game, you loose rotation speed by being hit by other spinners and gain rotation when you get kills. Spinners are subject to physics based collision, in other words, they hit each other and go flying! However, guns can chip away at enemy spinner's rotation at range, acting like a "slow beam" for rotational speed. Careful, some enemies have guns too. The player can regain some rotational velocity by getting kills or clearing rounds.

### Controls

-   Movement
    -   Up: W
    -   Down: S
    -   Left: A
    -   Right: D
-   Fire: SPACEBAR

A bullet will be fired each time the player presses the spacebar. This means that there is no built-in delay between bullets. The Unity Input System did not present an ideal solution for holding down the button and firing bullets on a timer without unnecessarily coupling two established components. However, the bullets are still individually distinguishable from one another, and it would take nothing short of an auto-clicker to change this.

## Your Additions

Unlike many Shmup games, this game will have physics-based interactions between the characters on screen. Additionally, these physics-based interations are tied directly to health. When two spinners collide they loose rotational speed, when rotational speed falls to 0 the spinner dies. This applies to both the player and the enemies. This also means that friendly fire between enemy spinners is possible. Unlike other SHMUP games, the player has free range of motion across an infinite plane rather than being tied to a scrolling screen or bound to screen-wrapping. Because of the free range of motion, the weapon is also different. Rather than simply shooting upward or in the direction of the player’s movement, the weapon aims toward the mouse and fires. This way, the player can defend themselves from all sides. 

## Enemies

**Standard Enemy** (red band) - These enemies seek out the player and attempt to collide with them. They're small and a little slower than the player, however they are the most plentiful of the enemies and can easily overwhelm the player.

**Shooter Enemy** (purple band) - These enemies will also approach the player's position, however, they are large and slow and tend to hang back out of the action. Instead of being a melee threat, when they get close to the player they shoot a fan of bullets out in a circle, causing chaos for friend and foe alike. Only one shooter enemy will spawn for every 5 standard enemies, so you could see one during your second round, or not until your 5th.

## Sources

-   All sprites are original work
- There were several code snippets copied from excercises and class slides:
    - Direction & vector movement
    - Bounding Circle collision detection
    - Gaussian distributuion
    - force-based interactions

## Known Issues

The forces involved in collisions are not accurate, momentum is not conserved when it should be. However, despite the fact that my physics sytem is essentially "faking it" (in my opinion) it works well enough to pass.

Enemies sometimes spawn inside player; the collisions are quickly resolved, but this can unfairly disadvantage the player.

### Requirements not completed

A classmate warned that my force/acceleration-based movement might violate the direction/velocity vector-based movement requirement since it is different from the algorithm we learned in class. I would argue that mine is just velocity-vector movement with force and acceleration vectors added on top, but depending on one's interpretation of the ruberic requirments this could count as something not completed. 

Additionally, I'm not sure how heavily we were supposed to stick to the requirement of choosing a scrolling or fixed world, but my unbound free-roam movement could be seen as a violation of this requirement. I would argue that my game simply scrolls in all directions, but I can definitely see the argument that the free-roaming view too radically diverges from the pillars of the genre.

