using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private GameObject currentPlayer;

    void Start()
    {
        // Initially, set player1 as the current player
        SwitchToPlayer(player1);
    }

    void Update()
    {
        // Check for a key press or any condition to trigger the player switch.
        if (Input.GetKeyDown(KeyCode.N))
        {
            // Switch players when the trigger condition is met.
            if (currentPlayer == player1)
            {
                SwitchToPlayer(player2);
            }
            else
            {
                SwitchToPlayer(player1);
            }
        }
    }

    void SwitchToPlayer(GameObject newPlayer)
    {
        // Deactivate the current player
        if (currentPlayer != null)
        {
            currentPlayer.SetActive(false);
        }

        // Activate the new player
        newPlayer.SetActive(true);

        // Update the reference to the current player
        currentPlayer = newPlayer;
    }
}
