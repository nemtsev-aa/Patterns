public class Stats {
    public int Strength { get; private set; }
    public int Intelligence { get; private set; }
    public int Agility { get; private set; }

    public Stats(int strength, int intelligence, int agility) {
        Strength = strength;
        Intelligence = intelligence;
        Agility = agility;
    }

    public void ModifyStats(int strengthModifier, int intelligenceModifier, int agilityModifier) {
        Strength += strengthModifier;
        Intelligence += intelligenceModifier;
        Agility += agilityModifier;
    }
}
