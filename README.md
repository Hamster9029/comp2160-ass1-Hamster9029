# COMP2160 Game Development - Individual Project

# Collaborators
- **Martin Cai** Programmer

## Purpose
This project was a technical prototype to ustilise the skills learnt and develop a arcade space shooter that included the following features: 

1. Player Movement
2. Player Attacks
3. Enemy Spawns
4. Enemy Attacks
5. Enemy Death
6. Enemy Drops
7. Coin Disappear after Specific Period
8. Player Death when Colliding with Enemy or Attacks
9. Points System
10. User Interface

## Framework
A basic framework is provided which includes a collection of extension scripts in the folder Assets/Scripts/Utils.

## Features
### 1. Player Movement
The player should be able to move using WASD with diagonal movement.

### 2. Player Attacks
The player should be able to shoot particles (bullets) at a fixed rate using the arrow keys with diagonal inputs and should be destroyed when leaving the screen or impacting an enemy.

### 3. Enemy Spawns
The enemies should be spawned at random positions and move across the screen to exit at a random position on the opposite side. The spawns should increase over time until it hits a maximum specified by the designer.

### 4. Enemy Attacks
The enemies should be able to launch one projectile at the player's currently position.

### 5. Enemy Death
The enemies should be destroyed when colliding with a bullet shot by the player and should not be affected by other projectile bullets fired from other enemies.

### 6. Enemy Drops
The enemies should spawn a coin at their location when they are defeated/destroyed.

### 7. Coin Disappear after Specific Period
Coins dropped by enemies should disappear after a specific period set by the designer.

### 8. Player Death when Colliding with Enemy or Attacks
The player is destroyed when colliding with either an enemy or an enemy projectile.

### 9. Points System
Points should be added when a player collides with a coin. The coin is also destroyed (collected).

### 10. User Interface (UI)
The game should present a simplistic UI for the players to view their current score and the highest score achieved. When the player dies a restart prompt will appear allowing players to play again.
