public struct CharacterStats {
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Agility { get; set; }

    public static CharacterStats operator +(CharacterStats charOne, CharacterStats charTwo) {
        return new CharacterStats() {
            Strength = charOne.Strength + charTwo.Strength,
            Intelligence = charOne.Intelligence + charTwo.Intelligence,
            Agility = charOne.Agility + charTwo.Agility
        };
    }
    public static CharacterStats operator *(CharacterStats charOne, CharacterStats charTwo) {
        return new CharacterStats() {
            Strength = charOne.Strength * charTwo.Strength,
            Intelligence = charOne.Intelligence * charTwo.Intelligence,
            Agility = charOne.Agility * charTwo.Agility
        };
    }

    public static CharacterStats operator *(CharacterStats charOne, float multiplier) {
        return new CharacterStats() {
            Strength = (int)(charOne.Strength * multiplier),
            Intelligence = (int)(charOne.Intelligence * multiplier),
            Agility = (int)(charOne.Agility * multiplier)
        };
    }

    public override string ToString() {
        return $"Strength: {Strength}, Intelligence: {Intelligence}, Agility: {Agility}";
    }
}
