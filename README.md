# 2D Game in a 3D World

A **3D side-scrolling runner** developed in Unity, combining classic 2D runner gameplay with a fully 3D environment.

> **Engine:** Unity 2022.3.62f3 LTS  
> **Language:** C#  
> **Rendering:** Universal Render Pipeline (URP)

## Overview

**2D Game in a 3D World** is a single-player side-scrolling runner in which the player must jump over incoming obstacles, interact with enemies, and survive long enough to reach the end of each level.

Although the gameplay follows a 2D side-scrolling structure, the player, enemies, obstacles, platforms, animations, physics, and environment are implemented using 3D Unity objects and systems.

The project focuses on core gameplay programming concepts such as physics-based movement, collision handling, randomized spawning, animation and audio feedback, scrolling environments, and scene progression.

## Gameplay Screenshots

<table>
<tr>
<td width="50%" align="center">
<img src="docs/screenshots/jump-gameplay.png" alt="Player jumping over obstacles" width="100%"><br>
<b>Physics-based jumping</b>
</td>
<td width="50%" align="center">
<img src="docs/screenshots/enemy-hit.png" alt="Enemy collision and hit counter" width="100%"><br>
<b>Enemy collision — hit counter</b>
</td>
</tr>
<tr>
<td width="50%" align="center">
<img src="docs/screenshots/game-over.png" alt="Game over after obstacle collision" width="100%"><br>
<b>Obstacle collision — Game Over</b>
</td>
<td width="50%" align="center">
<img src="docs/screenshots/level-2.png" alt="Second level environment" width="100%"><br>
<b>Level 2 environment</b>
</td>
</tr>
</table>

## Gameplay Features

- Physics-based jumping using Unity `Rigidbody`
- Custom gravity multiplier for responsive jump behavior
- Ground detection to prevent repeated mid-air jumps
- Animated jump and death states
- Jump and collision sound effects
- Moving obstacles and enemies that create a side-scrolling effect
- Randomized spawning of different obstacles and elevated platforms
- Random enemy spawning on platforms
- Multiple-hit enemy collision system
- Immediate game-over state when colliding with obstacles
- Repeating scrolling background
- Timed finish-point spawning
- Two-level progression using Unity Scene Management

## Game Flow

The project contains two gameplay levels:

```text
Level 1  →  Level 2  →  Game Complete
```

During gameplay, obstacles, platforms, and enemies are generated dynamically. A finish point appears after the player survives for a configured amount of time.

Reaching the Level 1 finish trigger loads **Level 2**, while reaching the final finish point ends the game.

## Controls

| Action | Control |
| --- | --- |
| Jump | `Space` |

## Gameplay Systems

The custom gameplay scripts are located in:

```text
Assets/Script/
```

| Script | Responsibility |
| --- | --- |
| `PlayerController.cs` | Jump physics, ground detection, animations, audio, collision handling, and game-over state |
| `SpawnManager.cs` | Randomized spawning of obstacles, platforms, enemies, and finish points |
| `MoveLeft.cs` | Moves world objects left to create the side-scrolling runner effect |
| `EnemyController.cs` | Enemy collision and death behavior |
| `RepeatBackground.cs` | Repositions the background to create continuous scrolling |
| `NextLevel.cs` | Handles transition from Level 1 to Level 2 |
| `FinishPoint.cs` | Detects completion of the final level |

## Selected Implementation Details

### Player Physics

The player uses Unity's `Rigidbody` system and applies an upward impulse when the **Space** key is pressed. A ground-state check prevents jumping again while airborne.

### Dynamic Obstacles

The spawn system periodically chooses between multiple gameplay objects:

- Standard obstacles
- Alternative obstacles
- Elevated platforms
- Enemies positioned on platforms

This creates variation between playthroughs instead of relying on a completely fixed obstacle sequence.

### Collision & Game Over

Obstacle collisions immediately trigger the player's game-over state.

Enemy collisions use a separate hit counter, allowing the player to withstand multiple enemy contacts before losing.

### Level Progression

Unity's `SceneManager` handles the transition between `Level1` and `Level2`. The final finish point stops gameplay once the second level is completed.

## Project Structure

```text
2D-Game-in-3D-World/
├── Assets/
│   ├── Scenes/
│   │   ├── Level1.unity
│   │   └── Level2.unity
│   ├── Script/                 # Gameplay C# scripts
│   ├── Course Library/         # Course-provided visual/audio assets
│   └── Settings/
├── docs/
│   └── screenshots/
├── Packages/
├── ProjectSettings/
└── README.md
```

## Running the Project

1. Clone the repository:

```bash
git clone https://github.com/aggelinho/2D-Game-in-3D-World.git
```

2. Open **Unity Hub**.
3. Choose **Add project from disk** and select the cloned repository.
4. Open the project with **Unity 2022.3.62f3 LTS**.
5. Open:

```text
Assets/Scenes/Level1.unity
```

6. Press **Play**.

Unity will regenerate local cache folders such as `Library/`, `Temp/`, and `Logs/`. These folders are intentionally excluded from version control.

## Technologies

- Unity 2022.3 LTS
- C#
- Unity 3D Physics / Rigidbody
- Unity Animator
- Unity Audio
- Unity Scene Management
- Universal Render Pipeline (URP)

## Asset Attribution

The project includes course-provided assets under `Assets/Course Library/`.

According to the included asset license, visual assets were provided by **Synty Studios**, while music and sound effects were provided by **cabled_mess** and **Cron Audio**. These assets are not presented as original work and remain subject to their respective license terms.

The original license information is retained in:

```text
Assets/Course Library/_Source_Files/_LICENSE.txt
```

The gameplay logic and C# implementation described in this README are presented separately from the third-party visual and audio assets.

## Author

**George Aggelis**  
GitHub: [@aggelinho](https://github.com/aggelinho)
