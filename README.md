# Maze Game with Fog of War

Maze Game with Fog of War generates a random maze, hides it behind fog of war,
and challenges you to reach the exit while only the area around your character
is visible. It is a Windows console app.

Built with C# on .NET Framework 4.8. This was my A-level Computer Science NEA
(Non-Exam Assessment) coursework project, written in 2023 and kept here as
submitted.

## How it works

**Maze generation.** The maze is a 2D character grid, 59 × 31 cells, starting
solid walls. Generation is depth-first search with recursive backtracking: the
four directions are shuffled Fisher–Yates style, the algorithm looks two cells
ahead, carves a path through the wall between, and recurses. The result is a
perfect maze — exactly one route between any two cells. A start (`S`) and an
end (`E`) marker are placed on random open cells.

**Fog of war.** A second grid, same size, tracks which cells have been
revealed. Each frame it marks a square of radius 3 around the player.
Everything unrevealed is drawn as a space, so the maze only exists where you
have walked.

**Game loop.** Clear the console, reveal around the player, draw the revealed
cells, check whether you have reached `E`, sleep 100 ms, repeat.

**Architecture.** One responsibility per class, wired together by constructor
injection — `GameController` receives the objects it works with rather than
creating them.

| Class | Responsibility |
|---|---|
| `Program` | Entry point: sets the maze size, creates the objects, starts the game |
| `Maze` | Model: the grid, generation, wall checks and cell access |
| `Fog_Of_War` | Reveal state: which cells are currently visible |
| `Player` | Position and input: arrow-key movement, blocked by walls |
| `GameController` | Game loop: reveal, render, win check |
| `UI` | Placeholder for display logic kept separate from the controller |

## Controls

Arrow keys to move. Reach `E` to win.

## Building from source

Windows only. .NET Framework 4.8.

1. Install Visual Studio 2022 with the **.NET desktop development** workload.
2. Open `Maze Generation With Fog Of War/Maze Generation With Fog Of War.sln`.
3. Press F5 to build and run (Ctrl+F5 to run without debugging).

Or from the command line with `msbuild`:

```bat
msbuild "Maze Generation With Fog Of War\Maze Generation With Fog Of War\Maze Generation With Fog Of War.csproj" /p:Configuration=Debug
"Maze Generation With Fog Of War\Maze Generation With Fog Of War\bin\Debug\Maze Generation With Fog Of War.exe"
```

## Project status

Kept as submitted (2023). Not in development.
