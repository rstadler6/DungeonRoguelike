using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Combat;

public class AttackManager
{
    private List<Attack> attacks = new();
    
    EnemyManager enemyManager;
    Character character;

    public AttackManager(EnemyManager enemyManager, Character character)
    {
        this.enemyManager = enemyManager;
        this.character = character;
    }
    
    public IReadOnlyCollection<Attack> Attacks => attacks.AsReadOnly();

    public void Update(GameTime gameTime)
    { 
        if (enemyManager.Enemies.Count == 0)
            return;
        
        attacks.AddRange(character.GetAttack(gameTime));

        foreach (var attack in attacks.ToList())
        {
            if (attack.Target != null)
            {
                var targetEnemy = enemyManager.Enemies.FirstOrDefault(e => e == attack.Target);
                if (targetEnemy != null)
                {
                    AttackEnemy(attack, targetEnemy);
                    continue;
                }
            }
            
            attack.Target = enemyManager.Enemies.OrderBy(e => Math.Abs(Vector2.DistanceSquared(e.Position, attack.Position))).First();
            AttackEnemy(attack, (Enemy)attack.Target);
        }
    }

    private void AttackEnemy(Attack attack, Enemy enemy)
    {
        attack.Move(enemy);
                    
        if (attack.TryDamage(enemy))
        {
            enemyManager.KillEnemy(enemy);
            attacks.Remove(attack);
        }
    }
}