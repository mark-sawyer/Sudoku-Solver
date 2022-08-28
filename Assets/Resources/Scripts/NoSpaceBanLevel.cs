
public class NoSpaceBanLevel {
    public Digit bannedDigit { get; private set; }
    public int level { get; private set; }

    public NoSpaceBanLevel(Digit bannedDigit, int level) {
        this.bannedDigit = bannedDigit;
        this.level = level;
    }
}
