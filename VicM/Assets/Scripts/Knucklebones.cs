using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnucklebonesGame : MonoBehaviour
{
    public Button[] playerGridButtons;
    public Button[] aiGridButtons;
    public Text diceRollText;
    public Text playerScoreText;
    public Text aiScoreText;

    private int[] playerGrid = new int[9];
    private int[] aiGrid = new int[9];
    private int currentDiceRoll;
    private bool isPlayerTurn = true;

    void Start()
    {
        ResetGame();
    }

    public void RollDice()
    {
        if (!isPlayerTurn) return; // Prevent rolling on AI's turn

        currentDiceRoll = Random.Range(1, 7); // Roll a dice (1-6)
        diceRollText.text = "Rolled: " + currentDiceRoll;
    }

    public void PlayerPlaceDice(int index)
    {
        if (!isPlayerTurn || playerGrid[index] != 0 || currentDiceRoll == 0) return;

        // Place dice in the grid
        playerGrid[index] = currentDiceRoll;
        playerGridButtons[index].GetComponentInChildren<Text>().text = currentDiceRoll.ToString();

        EndTurn();
    }

    private void AITurn()
    {
        int emptyIndex = System.Array.FindIndex(aiGrid, value => value == 0); // Find the first empty slot
        if (emptyIndex != -1)
        {
            int aiRoll = Random.Range(1, 7); // AI rolls a dice
            aiGrid[emptyIndex] = aiRoll;
            aiGridButtons[emptyIndex].GetComponentInChildren<Text>().text = aiRoll.ToString();
        }
        EndTurn();
    }

    private void EndTurn()
    {
        currentDiceRoll = 0;
        diceRollText.text = "";
        isPlayerTurn = !isPlayerTurn;

        // Check if game is over
        if (IsGridFull(playerGrid) && IsGridFull(aiGrid))
        {
            CalculateScores();
            return;
        }

        // If it's AI's turn, make its move
        if (!isPlayerTurn)
        {
            Invoke(nameof(AITurn), 1.0f); // Delay AI's move for clarity
        }
    }

    private void CalculateScores()
    {
        int playerScore = 0;
        int aiScore = 0;

        // Calculate scores column by column
        for (int i = 0; i < 3; i++) // 3 columns
        {
            playerScore += playerGrid[i] + playerGrid[i + 3] + playerGrid[i + 6];
            aiScore += aiGrid[i] + aiGrid[i + 3] + aiGrid[i + 6];
        }

        playerScoreText.text = "Player Score: " + playerScore;
        aiScoreText.text = "AI Score: " + aiScore;
    }

    private bool IsGridFull(int[] grid)
    {
        return System.Array.TrueForAll(grid, value => value != 0);
    }

    public void ResetGame()
    {
        currentDiceRoll = 0;
        isPlayerTurn = true;

        // Reset grids
        for (int i = 0; i < 9; i++)
        {
            playerGrid[i] = 0;
            aiGrid[i] = 0;

            playerGridButtons[i].GetComponentInChildren<Text>().text = "";
            aiGridButtons[i].GetComponentInChildren<Text>().text = "";
        }

        diceRollText.text = "Roll to Start!";
        playerScoreText.text = "Player Score: 0";
        aiScoreText.text = "AI Score: 0";
    }
}
