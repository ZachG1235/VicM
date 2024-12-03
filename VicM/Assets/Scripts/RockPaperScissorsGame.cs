using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;  // Add this namespace for TextMeshPro

public class RockPaperScissorsGame : MonoBehaviour
{
    // UI elements
    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;

    public TextMeshProUGUI resultText;

    // Enum to represent the choices
    public enum Choice { Rock, Paper, Scissors }
    private Choice playerChoice;
    private Choice computerChoice;

    // Start is called before the first frame update
    void Start()
    {
        // Set up button listeners
        rockButton.onClick.AddListener(() => MakeChoice(Choice.Rock));
        paperButton.onClick.AddListener(() => MakeChoice(Choice.Paper));
        scissorsButton.onClick.AddListener(() => MakeChoice(Choice.Scissors));
    }

    public void Exit()
    {
        SceneManager.LoadScene("CasinoLobby");
        GameManager.SGameManager.VicM.transform.position = Vector3.zero;
    }

    // Function that is called when a button is clicked
    void MakeChoice(Choice playerSelection)
    {
        playerChoice = playerSelection;
        computerChoice = (Choice)Random.Range(0, 3); // Randomly pick Rock, Paper, or Scissors

        // Determine the result
        string result = DetermineWinner(playerChoice, computerChoice);

        // Display the result
        resultText.text = $"You chose: {playerChoice}\nComputer chose: {computerChoice}\n{result}";
    }

    // Function to determine the winner
    string DetermineWinner(Choice player, Choice computer)
    {
        if (player == computer)
        {
            return "It's a Tie!";
        }

        if ((player == Choice.Rock && computer == Choice.Scissors) ||
            (player == Choice.Paper && computer == Choice.Rock) ||
            (player == Choice.Scissors && computer == Choice.Paper))
        {
            VicMStats.curSettings.maxHealth += 5;
            GameManager.SGameManager.VicM.GetComponent<Health>().MaximizeHealth();
            return "You Win! Increasing health!";
        }

        if (VicMStats.curSettings.defense >= 5)
        {
            VicMStats.curSettings.defense -= 5;
        }
        else
        {
            VicMStats.curSettings.defense = 0;
        }

        return "You Lose! Decreasing defense!";
    }
}
