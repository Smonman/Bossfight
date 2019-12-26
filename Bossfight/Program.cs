using System;
using System.Collections.Generic;
using System.Threading;

namespace Bossfight
{
	public enum DIRECTION {LEFT, RIGHT, TOP, BOTTOM };
	class Program
	{
		#region Variables

		static List<ConsoleKey> left = new List<ConsoleKey>()
		{
			ConsoleKey.LeftArrow, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D, ConsoleKey.F, ConsoleKey.NumPad4
		};
		static List<ConsoleKey> right = new List<ConsoleKey>()
		{
			ConsoleKey.RightArrow, ConsoleKey.J, ConsoleKey.K, ConsoleKey.L, ConsoleKey.NumPad6
		};
		static List<ConsoleKey> top = new List<ConsoleKey>()
		{
			ConsoleKey.UpArrow, ConsoleKey.E, ConsoleKey.R, ConsoleKey.T, ConsoleKey.Z, ConsoleKey.U, ConsoleKey.I,
			ConsoleKey.O, ConsoleKey.NumPad8
		};
		static List<ConsoleKey> bottom = new List<ConsoleKey>()
		{
			ConsoleKey.Spacebar, ConsoleKey.DownArrow, ConsoleKey.NumPad2
		};

		static List<List<ConsoleKey>> directions;
		#endregion
		static void Main(string[] args)
		{
			Centaur___Boss centaur = new Centaur___Boss();
			Player player = new Player(true); //set on true to test bossfight //set on false to test RunAway

			directions = new List<List<ConsoleKey>>() { left, right, top, bottom };

			if(!player.hasAllItems)
			{
				RunAway(player, centaur);
			}
			else
			{
				FightBoss(player, centaur);
			}

			player.CreatureDeathEvent += OnPlayerDeath;
			centaur.CreatureDeathEvent += OnCentaurDeath;


			Console.WriteLine("YOU LOST!" + "\t Press any key");
			Console.ReadKey();
		}

		static void RunAway(Player player, Centaur___Boss centaur)
		{
			//ToDo give the player info how to play "RunAway"
			int turns = 5;

			//ToDo durch AI ersetzen
			for(int i = 0; i < turns; i++)
			{
				//get an enum
				centaur.attackDirection = Centaur___Boss.GetAttackDirection();

				Console.WriteLine("The enemy attacks from " + centaur.attackDirection);

				//get an enum
				player.attackDirection = GetDirection(Player.GetDirectionKey());

				if(!IsOppositeDirection(centaur.attackDirection, player.attackDirection))
				{
					player.TakeDamage(1);
				}
			}

			Console.WriteLine("You escaped successfully");
		}

		static void FightBoss(Player player, Centaur___Boss centaur)
		{
			do
			{
				if(!centaur.isStunned)
				{
					//get an enum
					centaur.dodgeDirection = Centaur___Boss.GetDodgeDirection();
					centaur.attackDirection = Centaur___Boss.GetAttackDirection();

					Console.WriteLine("The enemy attacks from " + centaur.attackDirection);
				}
				else
				{
					Console.WriteLine("The centaur is stunned, you will get an free attack");
					centaur.TakeDamage(1);
					centaur.isStunned = false;
					Thread.Sleep(2000);
					Console.WriteLine("The centaur is no longer stunned");
					continue;
				}

				if(player.doubledamage)
				{
					Console.WriteLine("DOUBLE DAMAGE!");
				}

				//get an enum
				player.attackDirection = GetDirection(Player.GetDirectionKey());

				//
				Fight.Fightscene(centaur, player);

				Console.WriteLine();

				Console.WriteLine($"*Player:\t {player.lives}");
				Console.WriteLine($"*Shield:\t {player.shield.lives}");
				Console.WriteLine($"*Centaur:\t {centaur.lives}");

				Console.WriteLine();

			} while(player.lives > 0 && centaur.lives > 0);
		}

		static DIRECTION GetDirection(ConsoleKey k)
		{
			for(int i = 0; i < Enum.GetNames(typeof(DIRECTION)).Length; i++)
			{
				if(directions[i].Contains(k))
				{
					Console.WriteLine($"You chose: {(DIRECTION)i}");
					return (DIRECTION)i;
				}
			}


			return DIRECTION.LEFT;
		}
			
		public static bool IsOppositeDirection(DIRECTION attackDirection1, DIRECTION attackDirection2)
		{
			if(attackDirection1 == DIRECTION.RIGHT || attackDirection1 == DIRECTION.TOP)
			{
				if(attackDirection2 == DIRECTION.RIGHT || attackDirection2 == DIRECTION.TOP)
				{
					return false;
				}
			}
			if(Math.Abs((int)attackDirection1 - (int)attackDirection2) != 1)
			{
				//not the opposite direction
				return false;
			}

			//opposite direction
			return true;
		}

		static void OnPlayerDeath()
		{
			//ToDo eventhandler = start new game. Player died
		}

		static void OnCentaurDeath()
		{
			//ToDo eventhandler = won the game. Centaur died
		}
	}
}
