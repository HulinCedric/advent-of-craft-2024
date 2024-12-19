Feature: Rock Paper Scissors Game

    Scenario: <winner> wins with <player1_choice> over <player2_choice>
        Given Player 1 chooses <player1_choice>
        And Player 2 chooses <player2_choice>
        When they play
        Then the result should be <winner> because <reason>

    Examples:
      | player1_choice | player2_choice | winner   | reason                      |
      | 🪨             | ✂️             | Player 1 | rock crushes scissors       |
      | 🪨             | 🦎             | Player 1 | rock crushes lizard         |
      | 📄             | 🪨             | Player 1 | paper covers rock           |
      | 📄             | 🖖             | Player 1 | paper disproves spock       |
      | ✂️             | 📄             | Player 1 | scissors cuts paper         |
      | ✂️             | 🦎             | Player 1 | scissors decapitates lizard |
      | 🦎             | 🖖             | Player 1 | lizard poisons spock        |
      | 🦎             | 📄             | Player 1 | lizard eats paper           |
      | 🖖             | ✂️             | Player 1 | spock smashes scissors      |
      | 🖖             | 🪨             | Player 1 | spock vaporizes rock        |
      | ✂️             | 🪨             | Player 2 | rock crushes scissors       |
      | 🦎             | 🪨             | Player 2 | rock crushes lizard         |
      | 🪨             | 📄             | Player 2 | paper covers rock           |
      | 🖖             | 📄             | Player 2 | paper disproves spock       |
      | 📄             | ✂️             | Player 2 | scissors cuts paper         |
      | 🦎             | ✂️             | Player 2 | scissors decapitates lizard |
      | 🖖             | 🦎             | Player 2 | lizard poisons spock        |
      | 📄             | 🦎             | Player 2 | lizard eats paper           |
      | ✂️             | 🖖             | Player 2 | spock smashes scissors      |
      | 🪨             | 🖖             | Player 2 | spock vaporizes rock        |

    Scenario Outline: Draw
        Given Player 1 chooses <choice>
        And Player 2 chooses <choice>
        When they play
        Then the result should be Draw because same choice

        Examples:
          | choice |
          | 🪨     |
          | ✂️     |
          | 📄     |
          | 🦎     |
          | 🖖     |