# Project SPINNERSCORGE

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

### Student Info

-   Name: AUDEN CLIFFORD
-   Section: #02

## Game Design

-   Camera Orientation: topdown
-   Camera Movement: follows player
-   Player Health: heathbar; tied to rotational velocity (you die when you stop spinning)
-   End Condition: game ends when the player dies; the object is to get as high a score as possible before that happens
-   Scoring: kills and time; time acts as base points, kills multiply score

### Game Description

SPINNERSCORGE, beyblades with guns. In spinnerscorge, you play as a spinner/top and must survive as long as possible against other spinners. If you stop spinning your out of the game, you loose rotation speed by being hit by other spinners and gain rotation when you get kills. Spinners are subject to physics based collision, in other words, they hit each other and go flying! However, guns can chip away at enemy spinner's rotation at range, acting like a "slow beam" for rotational speed. Careful, some enemies have guns too. The player only regains speed from kills done via bumping into enemies. Therefore the player must use the gun to slow down enemies and then go in for the kill at melee range.

### Controls

-   Movement
    -   Up: W
    -   Down: S
    -   Left: A
    -   Right: D
-   Fire: SPACEBAR

## Your Additions

Unlike many Shmup games, this game will have physics-based interactions between the characters on screen. Additionally, these physics-based interations are tied directly to health. When two spinners collide they loose rotational speed, when rotational speed falls to 0 the spinner dies. This applies to both the player and the enemies. This also means that friendly fire between enemy spinners is possible.

## Sources

-   _List all project sources here –models, textures, sound clips, assets, etc._
-   _If an asset is from the Unity store, include a link to the page and the author’s name_

## Known Issues

- bullets fired by the player collide with the player

### Requirements not completed

_If you did not complete a project requirement, notate that here_

