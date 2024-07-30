public class RAM {
    private final RAMType PAMType;
    private final int RAMAmount; // в Мб
    private final double RAMWeight; //в граммах

    public RAM(RAMType PAMType, int RAMAmount, double RAMWeight) {
        this.PAMType = PAMType;
        this.RAMAmount = RAMAmount;
        this.RAMWeight = RAMWeight;
    }

    public double getRAMWeight () {
        return RAMWeight;
    }

    public String getRAMInfo () {
        return "типа " + PAMType.getRAMType() +
                ", объем " + RAMAmount + " Мб";
    }
}
