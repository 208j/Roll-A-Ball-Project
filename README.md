# Roll-A-Ball-Project

## How to run the project

### From Unity Editor
- Open the project in Unity .
- Open the main scene .
- Press the **Play** button in the editor to start the game.

### From build
- Go to the `Builds` folder or open `3D Roll_a_ball project.zip` file.
- On Windows, run the main executable file, for example: `3D Roll_a_ball project.exe`.
- Make sure the `.exe` file is in the same folder as the `3D Roll_a_ball project_Data` folder and other build files (do not move the `.exe` alone).

## Controls

- **W / A / S / D** or arrow keys – move the ball.
- **Space** – jump (only when the ball is on the ground).
- **Left Mouse Button on the game world (not on UI)** – lock the cursor and switch to gameplay control.
- **Esc** – unlock the cursor so you can click UI buttons.
- **Pause button** (top-right corner during gameplay) – open the pause menu.
- **Resume** – continue the game after pause.
- **Restart** – restart the current level.
- **Exit** – quit the game (in build) or stop Play Mode (in Unity Editor).

## Project description

This is a simple 3D Roll-a-Ball style game: the player controls a ball on a platform, collects pickup objects, avoids an enemy, and tries to collect all pickups to win.
The project extends the basic Unity Roll-a-Ball tutorial by adding a start menu, pause menu, cursor handling that distinguishes between clicking on the game world and on UI elements, and background music.

Main elements:
- Player ball using a `Rigidbody` for physics-based movement.
- Enemy that chases the player.
- Collectible pickups that increase the score.
- UI: score counter, start menu, pause menu, win/lose messages, pause button.

## Custom features

Compared to the basic Roll-a-Ball tutorial, this project includes:

- Start menu
  - Start menu panel with Start and Exit buttons.
  - When the game launches, time is stopped (`Time.timeScale = 0`) and only the start screen is visible.

- Pause system
  - A Pause button in the in-game HUD.
  - Pause menu with Resume and Restart buttons.
  - While paused, time is stopped (`Time.timeScale = 0`), HUD is hidden, and player movement is disabled.

- GameManager
  - `GameManager` script controls:
    - start menu;
    - pause state;
    - win/lose state;
    - HUD visibility;
    - restart and exit logic.
  - Static field `GameManager.isPaused` so other scripts can check if the game is paused.

- Cursor lock logic
  - At start and in menus, the cursor is unlocked and visible.
  - During gameplay, the cursor is locked and hidden.
  - Left-click on the game world (when not over UI) locks the cursor and returns to gameplay.
  - Esc is used only to unlock the cursor, not to open the pause menu.

- Win/Lose state
  - When the player collects the required number of pickups, a win message is shown and the game is stopped.
  - When the player collides with the enemy, a lose message is shown and the game is stopped.
  - In both cases, Restart and **Exit buttons are available.

## Division of responsibilities

The work on the project was split between two contributors based on the Git commit history.

 Ilkham Amirzhanov:
- Created the game environment, including the ground, walls, lighting, and player materials.
- Set up and assigned the `CameraController` script and adjusted the camera position.
- Built the user interface structure, including the **StartMenu** and **PauseMenu**.
- Created the `GameManager` script to control menus, pause logic, cursor behavior, restart, and exit functions.
- Configured the final build and added background music.
- Performed cleanup and fixes during development.

 Yernur Nurzhigit:
- Created and refined the player controller and movement physics.
- Added the jump mechanic.
- Created the pickup objects and converted them into a prefab.
- Added the `Rotator` script for pickup animation.
- Implemented `OnTriggerEnter` for pickup collection.
- Created the enemy object and later added NavMesh-based enemy movement.
- Implemented the score display and related text logic.
