using Assets.Visitor;
using System;
using System.Collections.Generic;

public class EnemyVisitor : IEnemyVisitor {
    private Dictionary<Type, int> _weightDictionary = new Dictionary<Type, int>() {
        {typeof(Ork), 5 },
        {typeof(Human), 2 },
        {typeof(Elf), 1 },
        {typeof(Robot), 3 },
        {typeof(Dwarf), 4 }
    };

    public int Weight { get; private set; }

    public void Visit(Enemy enemy) => Visit((dynamic)enemy);

    public void Visit(Ork ork) => Weight += _weightDictionary[typeof(Ork)];

    public void Visit(Human human) => Weight += _weightDictionary[typeof(Human)];

    public void Visit(Elf elf) => Weight += _weightDictionary[typeof(Elf)];

    public void Visit(Robot robot) => Weight += _weightDictionary[typeof(Robot)];

    public void Visit(Dwarf dwarf) => Weight += _weightDictionary[typeof(Dwarf)];
}