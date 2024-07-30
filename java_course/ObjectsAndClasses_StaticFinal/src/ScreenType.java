public enum ScreenType {
    IPS("IPS"),
    TN ("TN"),
    VA("VA");
    private String screenType;
    ScreenType(String screenType) {
        this.screenType = screenType;
    }
    public String getScreenType() {
        return screenType;
    }
}
