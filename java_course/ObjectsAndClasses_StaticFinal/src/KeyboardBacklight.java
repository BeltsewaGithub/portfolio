public enum KeyboardBacklight {
    YES ("есть подстветка"),
    NO ("без подсветки");

    private String backlight;
    KeyboardBacklight(String backlight) {
        this.backlight = backlight;
    }

    public String getBacklight() {
        return backlight;
    }
}
