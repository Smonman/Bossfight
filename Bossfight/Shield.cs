using System;
using System.Collections.Generic;
using System.Text;

namespace Bossfight
{
	class Shield : Creature
	{
		Random rnd = new Random();

		public override void TakeDamage(int amount)
		{
			base.TakeDamage(amount);
			Console.WriteLine($"Your shield took {amount} damage. It has {lives} left.");

			if(lives <= 0)
			{
				OnDeath();
			}
		}

		public override void OnDeath()
		{
			Console.WriteLine("Your shield got destroyed");
		}

		public void TakeHit(double blockchance, Player player, bool dd, Centaur___Boss centaur)
		{
			Random eventchances = rnd;
			int amount = dd ? 2 : 1;

			#region shield is broken && doubledamage ?= true
			//double damage
			if(lives <= 0)
			{
				amount = 1;
				player.TakeDamage(amount);
				return;
			}

			if(dd)
			{
				double stunchance = eventchances.NextDouble();
				centaur.isStunned = stunchance < 0.18 ? true : false;
			}
			#endregion
			//Chance to block the enemy attack
			if(rnd.NextDouble() <= blockchance)
			{
				this.TakeDamage(amount);
			}
			else
			{
				//failed to block the attack
				player.TakeDamage(amount);
			}

			//chance to get doubledamage
			double doubledamagechange = eventchances.NextDouble();
			player.doubledamage = doubledamagechange < 0.04 ? true : false;
		}
	}
}
