using System;
using System.Collections.Generic;
using System.Text;

namespace Bossfight
{
	class Centaur___Boss : Creature
	{
		#region Variables
		public DIRECTION dodgeDirection
		{
			get; set;
		}

		public DIRECTION attackDirection
		{
			get; set;
		}

		public bool isStunned
		{
			get; set;
		}
		#endregion
		public Centaur___Boss(int lives = 5)
		{
			this.lives = lives;
			this.dodgeDirection = 0; //left as default
			this.attackDirection = 0; //same as dodge
			this.isStunned = false;
		}

		public static DIRECTION GetAttackDirection()
		{
			Random rnd = new Random();

			return (DIRECTION)rnd.Next(0,4);
		}

		public static DIRECTION GetDodgeDirection()
		{
			Random rnd = new Random();

			return (DIRECTION)rnd.Next(0, 4);
		}

		public override void TakeDamage(int amount)
		{
			base.TakeDamage(amount);
			Console.WriteLine($"The centaur took {amount} damage. It has {lives} left.");

			if(lives <= 0)
			{
				OnDeath();
			}
		}

		public override void OnDeath()
		{
			base.OnDeath();
			Console.WriteLine("Centaur died");
		}
	}
}
