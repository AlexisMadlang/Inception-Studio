
using UnityEditor.Experimental.GraphView;
using UnityEngine;


/// <summary>
/// Implements the game mechanics for the Monty Hall simulation.
/// ===========================================================================
/// This script is substantially modified based on the generated output
/// from a Large Language Model (LLM).
/// </summary>
public class MontyHall : MonoBehaviour
{
    // User-defined array to hold the three platforms
    [SerializeField]
    GameObject[] platforms;  

    private int winningPlatform;     // Scene index of the platform with cars
    private int chosenPlatform;      // Player's choice of platform
    private int revealedPlatform;    // Revealed platform

    // A boolean to keep track of the state of the game
    private bool gameEnded = false;  

    // Colors for the platforms
    private Color defaultColor = Color.gray;
    private Color chosenColor = Color.white;
    private Color revealedColor = Color.yellow;
    private Color winningColor = Color.green;


    // On awake, initialize the game
    void Awake()
    {
        InitializeGame();
    }


    /// <summary>
    /// Assign a scene index for the platforms, 
    /// with the winning platform teleporting the player to the car scene,
    /// while the losing platforms teleports the player to the goat scene.
    /// </summary>
    void InitializeGame()
    {
        // Randomly assign the winner behind one of the platforms
        winningPlatform = Random.Range(0, platforms.Length);

        // For each platform:
        for (int i = 0; i < platforms.Length; i++)
        {
            // Grab their material and reset their colors to default
            platforms[i].GetComponent<MeshRenderer>().material.color = defaultColor;

            // Grab their Platform component and set their scene indices
            // based on what the winning platform is.

            /* Your code here */
            if (i == winningPlatform)
            {
                platforms[i].GetComponent<Platform>().targetSceneId = -1;
            }
            else
            {
                platforms[i].GetComponent<Platform>().targetSceneId = 2;
            }
        }       
    
            
             

        // Initialize player's choice and the revealed platform
        // as neither of the platforms
        chosenPlatform = -1;
        revealedPlatform = -1;
        gameEnded = false;
    }

    void Update()
    {
        // If the game is still ongoing (not ended) ...
        if (!gameEnded)
        {
            // ... then players can choose a platform by pressing
            // number keys 1, 2, and 3.
            for (int i = 0; i < platforms.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    PlayerChoosePlatform(i);
                }
            }
        }

        // If the game is ended and the player presses the R-key,
        // then the game restarts and the platforms are reinitialized.
        if (gameEnded && Input.GetKeyDown(KeyCode.R))
        {
            InitializeGame();
        }
    }


    /// <summary>
    /// Implements the action of the player choosing a platform.
    /// </summary>
    /// <param name="choice">The chosen index for the platform.</param>
    void PlayerChoosePlatform(int choice)
    {
        // If the player has not previously chosen any platform...
        if (chosenPlatform == -1)
        {
            // Then the chosen platform is set to the player's choice.
            chosenPlatform = choice;

            // The platform changes color
            platforms[chosenPlatform].GetComponent<Renderer>().material.color = chosenColor;

            // The host will reveal another platform
            RevealHostPlatform();
        }
        else // If player chooses again after host reveals ...
        {
            // Set the choice again
            chosenPlatform = choice;

            // The chosen platform changes color again
            platforms[chosenPlatform].GetComponent<Renderer>().material.color = chosenColor;

            // Check if the player wins (make the choice of where the car scene is).
            CheckWin();
        }
    }


    /// <summary>
    /// The host reveals a platform after the player chooses one.
    /// </summary>
    void RevealHostPlatform()
    {
        // Reveal one of the remaining platforms that does not have the prize
        for (int i = 0; i < platforms.Length; i++)
        {
            if (i != chosenPlatform && i != winningPlatform)
            {
                revealedPlatform = i;
                platforms[revealedPlatform].GetComponent<Renderer>().material.color = revealedColor;
                break;
            }
        }
    }

    /// <summary>
    /// The game ends after the player makes two choices,
    /// and the results are checked to determine whether the player wins.
    /// </summary>
    void CheckWin()
    {
        // End the game
        gameEnded = true;

        // Check the result against the initialized values
        for (int i = 0; i < platforms.Length; i++)
        {
            // Changes the colors for the winning platform accordingly
            if (i == winningPlatform)
            {
                platforms[i].GetComponent<Renderer>().material.color = winningColor;
            }
            else if (i != revealedPlatform && i != winningPlatform)
            {
                platforms[i].GetComponent<Renderer>().material.color = chosenColor;
            }
        }

        // Print the result on the Console window.
        if (chosenPlatform == winningPlatform)
        {
            Debug.Log("You win!");
        }
        else
        {
            Debug.Log("You lose! The winning platform was: " + (winningPlatform + 1));
        }
    }
}