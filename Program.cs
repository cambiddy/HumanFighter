using HumanFighter.Logic;
using HumanFighter.Models;
using static System.Console;


#region colors
string NL = Environment.NewLine; // shortcut
string NORMAL = IsOutputRedirected ? "" : "\x1b[39m";
string RED = IsOutputRedirected ? "" : "\x1b[91m";
string GREEN = IsOutputRedirected ? "" : "\x1b[92m";
string YELLOW = IsOutputRedirected ? "" : "\x1b[93m";
string BLUE = IsOutputRedirected ? "" : "\x1b[94m";
string MAGENTA = IsOutputRedirected ? "" : "\x1b[95m";
string CYAN = IsOutputRedirected ? "" : "\x1b[96m";
string GREY = IsOutputRedirected ? "" : "\x1b[97m";
string BOLD = IsOutputRedirected ? "" : "\x1b[1m";
string NOBOLD = IsOutputRedirected ? "" : "\x1b[22m";
string UNDERLINE = IsOutputRedirected ? "" : "\x1b[4m";
string NOUNDERLINE = IsOutputRedirected ? "" : "\x1b[24m";
string REVERSE = IsOutputRedirected ? "" : "\x1b[7m";
string NOREVERSE = IsOutputRedirected ? "" : "\x1b[27m";
#endregion

int round = 0;


WriteLine(RED + $"Welcome to the Human Fighter!" + NORMAL);
WriteLine("We have successfully invaded Earth. You must now fight humans to eliminate the building resistance and assert our dominance over the planet.");
WriteLine("What was your name, alien?");
string getName = ReadLine();

Player player = new()
{
    UserName = getName,
    UserHP = 115
};

Clear();
WriteLine("Ah that's right. We've too many soldiers to keep track of.");
WriteLine("It's time for you to get out there and start eliminating resistance, "+ player.UserName + ". Good luck!");
WriteLine(NL);
WriteLine("Press any key to continue...");
ReadKey();
Clear();
newRound();


void newRound()
{
    playerInfoDisplay(player);
    enemyInfoDisplay(EntityLogic.NewEnemy(round));

    userChoice(player, EntityLogic.NewEnemy(round));
}




static void playerInfoDisplay(Player player)
{

    WriteLine(player.UserName);
    WriteLine("HP: " + player.UserHP);
}

static void enemyInfoDisplay(Entities enemy)
{
    WriteLine("You are now fighting: " + enemy.Name);
    WriteLine(enemy.Description);
    WriteLine(enemy.Name + " HP: " + enemy.EnemyHP);
}

static int diceRoll(string nameOfRoller)
{
    int diceValue = 0;
    Random rand1 = new();
    Random rand2 = new();
    int Die1 = rand1.Next(1, 13);
    int Die2 = rand2.Next(1, 13);
    if (Die1 == Die2)                                           
    {                                                           
        diceValue = (Die1 + Die2) * 2;                           
    }
    else

    {
        diceValue = Die1 + Die2;
    }
    WriteLine(nameOfRoller + " rolled a " + Die1);
    WriteLine("And a " + Die2);
    return diceValue;

}

void userChoice(Player player, Entities enemy)
{
    WriteLine(NL);
    WriteLine(NL);
    WriteLine(NL);

    WriteLine("What would you like to do now?");
    WriteLine("0:Heal");
    WriteLine("1:Attack");
    switch (usrActionInput(0, 1)){
        case 0:
            Clear();
            player.UserHP = Heal(player.UserHP, player.UserName);
            playerInfoDisplay(player);
            enemyInfoDisplay(enemy);
            WriteLine("Press any key to continue...");
            ReadKey();
            enemyChoice(player, enemy);
            break;
        case 1:
            Clear();
            enemy.EnemyHP = attack(enemy.EnemyHP, player.UserName, enemy.Name);
            playerInfoDisplay(player);
            enemyInfoDisplay(enemy);
            WriteLine("Press any key to continue...");
            ReadKey();
            if (enemy.EnemyHP <= 0)
            {
                Clear();
                winScreen(player.UserName, enemy.Name);
                round = round + 1;

                newRound();


            }
            else
            {
                enemyChoice(player, enemy);
            }
             break;
        default:
            WriteLine("ERROR");
            userChoice(player, enemy);
            break;
    }
}

void enemyChoice(Player player, Entities enemy)
{

    if (enemy.EnemyHP <= (enemy.StartHP / 4))
    {
        Clear();
        enemy.EnemyHP = Heal(enemy.EnemyHP, enemy.Name);
        playerInfoDisplay(player);
        enemyInfoDisplay(enemy);
        userChoice(player, enemy);

    }
    else
    {
        Clear();
        int newHP = attack(player.UserHP, enemy.Name, player.UserName);

        player.UserHP = newHP;
        playerInfoDisplay(player);
        enemyInfoDisplay(enemy);
        if (player.UserHP <= 0)
        {
            Clear();
            WriteLine("Sorry " + player.UserName + ", you have been defeated by " + enemy.Name);
            WriteLine("0:Play again");
            WriteLine("1:Quit");
            switch (usrActionInput(0, 1))
            {
                case 0:
                    player.UserHP = 115;
                    round = 0;
                    Clear();
                    newRound();
                    break;
                case 1:
                    break;
            }
        }
        else
        {
            userChoice(player, enemy);
        }
    }
}

int Heal(int entityHP, string entityName)
{
    int healFor = diceRoll(entityName);
    WriteLine(entityName + " Has healed for " + healFor + " HP!");
    return entityHP + healFor;
}

int attack(int attackedHP, string attackerName, string attackedName)
{
    int attackFor = diceRoll(attackerName);
    WriteLine(attackerName + " Has attacked " + attackedName + " for " + attackFor + " HP!");
    return attackedHP - attackFor;
}

static int usrActionInput(int rFrom, int rTo)
{
    int usrAction = 0;
    bool x = false;
    while (x == false)
    {
        string actionInput = ReadLine();



        if (int.TryParse(actionInput, out usrAction) && (rFrom <= usrAction) && (usrAction <= rTo))
        {
            x = true;
        }
        else
        {
            WriteLine("Please enter a valid number between " + rFrom + " and " + rTo + ":");
        }

    }
    return usrAction;
}

static void winScreen(string playerName, string enemyName)
{
    WriteLine("Congratulations, " + playerName + ", you defeated " + enemyName + "! Now it's time to move on to your next opponent!");
    WriteLine("Press any key to continue...");
    ReadKey();
    Clear();
}


