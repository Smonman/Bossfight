using System;
using System.Collections.Generic;
using System.Text;

namespace Bossfight
{
	class Creature
	{
		public delegate void CreatureDeathDelegate();
		public event CreatureDeathDelegate CreatureDeathEvent;

		public int lives;
		public Creature()
		{

		}
		public virtual void TakeDamage(int amount)
		{
			lives -= amount;
		}

		public virtual void OnDeath()
		{
			if(CreatureDeathEvent != null)
			{
				CreatureDeathEvent.Invoke();
			}
		}
	}
}
