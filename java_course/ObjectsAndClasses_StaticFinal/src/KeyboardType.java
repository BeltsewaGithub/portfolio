public enum KeyboardType {
    MEMBRANE ("мембранная, "),
    MECHANICAL("механическая, ");

    private String type;

    KeyboardType(String type) {
        this.type = type;
    }
    public String getType() {
        return type;
    }
}
