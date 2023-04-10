using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace The_Witch_Tale
{
	public enum MonsterType
	{
		Goblin = 0,
		Daddy = 1,
		GiantSpider = 2,
		Him = 3,
		Troll = 4,
		TreassureGuard = 5
	}
	public abstract class Monster
	{
		public int Health;
		public int Armour;
		public int Attack;
		public int Exp;

		public string Discription;
		public string Name;
		public MonsterType Type;

		protected int DamageResult(int damage, int armour)
		{
			int totalDamage = damage - armour;
			if (totalDamage < 0)
			{
				totalDamage = 0;
			}
			return totalDamage;

		}
		public virtual void MonsterSkill(Character Hero)
		{
			Console.WriteLine();
		}
		public void MonsterAttack(Character Hero)
		{
			int damage = DamageResult(Attack, Hero.Armour);
			Hero.Health -= damage;

			Console.WriteLine("{0} наносит вам {1} урона", Name, damage);
			Console.WriteLine();
		}

	}
}
