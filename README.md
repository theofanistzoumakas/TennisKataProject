# Tennis Kata Project

> A RESTful API implementation for a simple Tennis Game, each set is a single game. It tracks Tennis Scores (Love, 15, 30, 40, Deuce, Advantage) and determines the winner.

## Solution Archtecture

The Solution consists of 2 main Projects: `TennisKataProject` and `TennisKata.Test`.

### 1. The TennisKataProject (Main API):

* **Models:**
	* `TennisGame`: The data model representing the state of a game.
* **Controllers:**
	* `TennisController`: Handles HTTP requests and responses.
	* `StartGame` (POST method): Creates and returns a new tennis game.
	* `ShowScore` (GET method): Returns the current score of a game, based on its ID.
	* `PlayerScores` (POST method): Adds a point for to a player and updates the game state.
* **Services:**
	* `TennisService:`
		* `CalculateScore`: Evaluates player points and returns the correct tennis score string (e.g. "Deuce","Advantage of PLayer 1").

### 2. TennisKata.Test (Tests):

* `TennisControllerTest`: It has tests for the Controller class TennisController.
* `TennisServiceTest`: It has tests for the Service class TennisService.

## API Endpoints:

* `POST /api/Tennis` - Creates a new game.
* `GET /api/Tennis/{id}` - Gets the current score.
* `POST /api/Tennis/{id}/{player}/score` - Adds a point to a player.

## **Usage Note:** To score a point, you must First initialize a game.

* Execute `POST /api/Tennis` to create a game.
* Copy the `id` from the response.
* Use that ID int the URL of the scoring endpoint (e.g., `POST /api/Tennis/1/Player1/score`)

## Technologies Used:

* **ASP.NET Core Web API**.
* **Entity Framework Core In-Memory Database** - Used for rapid testing and development. *(Note: Data is ephemeral and will be deleted when the application stops or restarts. This keeps the project simple, as no external SQL server is required.)*
* **xUnit** (for Test-Driven-Development).
* **Swagger / OpenAPI**.



## Compile and Run:

To set up the project locally:  

1. **Clone the repository (or download and decompress the ZIP file)**
```bash
git clone https://github.com/theofanistzoumakas/TennisKataProject.git
cd TennisKataProject
```

2. **Open the project in Visual Studio 2022 using the .sln file**
3. **Visual Studio should restore NuGet packages automatically, but ensure the following are present**:
  - Main Project:
    - Microsoft.EntityFrameworkCore.InMemory (version 8.0.25)
  - Test Project:
    - Microsoft.EntityFrameworkCore.InMemory (version 8.0.25)
    - xUnit (version 2.9.3)
    - xunit.runner.visualstudio (version 3.1.5)

4. **Verify Target Framework**:
  * In your .csproj file, ensure the framework is set correctly:
```xml
<TargetFramework>net8.0</TargetFramework>
```

5. **Run the web application from Visual Studio**

## Running the Tests:

**On the top menu, click "Test" and "Run All Tests"**.
