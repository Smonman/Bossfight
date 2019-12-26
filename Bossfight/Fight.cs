using System;
using System.Collections.Generic;
using System.Text;

namespace Bossfight
{
	class Fight
	{
		public static Random fightrnd = new Random();

		public static void Fightscene(Centaur___Boss centaur, Player player)
		{
			switch(centaur.attackDirection)
			{
				case DIRECTION.LEFT:
					CentaurLeft(player, centaur);
					break;
				case DIRECTION.RIGHT:
					CentaurRight(player, centaur);
					break;
				case DIRECTION.TOP:
				case DIRECTION.BOTTOM:
					CentaurTopBottom(player, centaur);
					break;
			}
		}

		//centaur attacks left
		private static void CentaurLeft(Player player, Centaur___Boss centaur)
		{
			switch(player.attackDirection)
			{
				//player blocks left
				case DIRECTION.LEFT:
					player.shield.TakeHit(1.00, player, true, centaur);
					break;
				//player attacks right
				case DIRECTION.RIGHT:
					if(!Program.IsOppositeDirection(centaur.dodgeDirection, player.attackDirection))
					{
						//centaur didn't dodged
						player.Attack(false, centaur);
						player.shield.TakeHit(0.07, player, false, centaur);
					}
					else
					{
						Console.WriteLine($"Centaur dodged {centaur.dodgeDirection}");
						player.shield.TakeHit(0.07, player, false, centaur);
					}
					break;
				//player dodge top
				case DIRECTION.TOP:
					if(!Program.IsOppositeDirection(centaur.attackDirection, player.attackDirection))
					{
						player.shield.TakeHit(0.07, player, false, centaur);
					}
					break;
				//player dodge bottom
				case DIRECTION.BOTTOM:
					if(!Program.IsOppositeDirection(centaur.attackDirection, player.attackDirection))
					{
						player.shield.TakeHit(0.07, player, false, centaur);
					}
					break;
			}
		}

		//centaur attacks right
		private static void CentaurRight(Player player, Centaur___Boss centaur)
		{
			switch(player.attackDirection)
			{
				//player blocks left
				case DIRECTION.LEFT:
					player.shield.TakeHit(1.00, player, false, centaur);
					break;
				//players attacks right
				case DIRECTION.RIGHT:
					if(!Program.IsOppositeDirection(centaur.dodgeDirection, player.attackDirection))
					{
						//centaur didn't dodged
						player.Attack(false, centaur);
						if(fightrnd.NextDouble() > 0.50)
						{
							Console.WriteLine("failed counterattack");
							player.shield.TakeHit(0.07, player, false, centaur);
						}
						else
						{
							Console.WriteLine("Successfully counterattack");
						}
					}
					else
					{
						Console.WriteLine($"Centaur dodged {centaur.dodgeDirection}");
						player.shield.TakeHit(0.07, player, false, centaur);
					}
					break;
				//player dodge top
				case DIRECTION.TOP:
					if(!Program.IsOppositeDirection(centaur.attackDirection, player.attackDirection))
					{
						player.shield.TakeHit(0.07, player, false, centaur);
					}
					break;
				//player dodge bottom
				case DIRECTION.BOTTOM:
					if(!Program.IsOppositeDirection(centaur.attackDirection, player.attackDirection))
					{
						player.shield.TakeHit(0.07, player, false, centaur);
					}
					break;
			}
		}

		//centaur attacks top
		private static void CentaurTopBottom(Player player, Centaur___Boss centaur)
		{
			switch(player.attackDirection)
			{
				//player blocks left
				case DIRECTION.LEFT:
					player.shield.TakeHit(1.00, player, false, centaur);
					break;
				//players attacks right
				case DIRECTION.RIGHT:
					if(!Program.IsOppositeDirection(centaur.dodgeDirection, player.attackDirection))
					{
						//centaur didn't dodged
						player.Attack(false, centaur);
						player.shield.TakeHit(0.07, player, false, centaur);
					}
					else
					{
						Console.WriteLine($"Centaur dodged {centaur.dodgeDirection}");
						player.shield.TakeHit(0.07, player, false, centaur);
					}
					break;
				//player dodge top
				case DIRECTION.TOP:
					if(!Program.IsOppositeDirection(centaur.attackDirection, player.attackDirection))
					{
						player.shield.TakeHit(0.07, player, false, centaur);
					}
					break;
				//player dodge bottom
				case DIRECTION.BOTTOM:
					if(!Program.IsOppositeDirection(centaur.attackDirection, player.attackDirection))
					{
						player.shield.TakeHit(0.07, player, false, centaur);
					}
					break;
			}
		}
	}
}