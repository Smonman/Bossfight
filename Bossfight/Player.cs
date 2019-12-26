using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Bossfight
{
	class Player : Creature
	{
		#region Variables
		public bool hasAllItems
		{
			get; set;
		}
		public DIRECTION attackDirection
		{
			get; set;
		}

		public bool doubledamage
		{
			get; set;
		}

		public Shield shield = new Shield();
		#endregion

		public Player(bool hasAllItems, bool doubledamage = false, int lives = 3, int shieldlives = 5)
		{
			this.hasAllItems = hasAllItems;
			this.doubledamage = doubledamage;
			this.lives = lives;
			this.attackDirection = 0; //left as default
			this.shield.lives = 5;
		}

		public void Attack(bool ca, Centaur___Boss centaur)
		{
		
			Random eventchances = new Random();

			//double counterattackchange = eventchances.Next(0, 1); was meine ich mit counterattack?=?=????

			if(!doubledamage)
			{
				centaur.TakeDamage(1);
			}
			else
			{
				centaur.TakeDamage(2);
				doubledamage = false;
			}

		}

		public override void TakeDamage(int amount)
		{
			base.TakeDamage(amount);
			Console.WriteLine($"You took {amount} damage. U have {lives} left.");

			if(lives <= 0)
			{
				OnDeath();
			}
		}

		public override void OnDeath()
		{
			base.OnDeath();
			Console.WriteLine("You died");
		}

		public static ConsoleKey GetDirectionKey()
		{
			return Console.ReadKey().Key;
		}
	}
}
