public enum RAMType {
    DDR4 ("DDR4"),
    DDR3 ("DDR3");

    private String RAMType;
    RAMType(String RAMType) {
        this.RAMType = RAMType;
    }

    public String getRAMType(){
        return RAMType;
    }
}
