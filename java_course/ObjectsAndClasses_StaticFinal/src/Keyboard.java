public class Keyboard {
    private final KeyboardType keyboardType;
    private final KeyboardBacklight keyboardBacklight;
    private final double keyboardWeight; //в граммах

    public Keyboard(KeyboardType keyboardType, KeyboardBacklight keyboardBacklight, double keyboardWeight) {
        this.keyboardType = keyboardType;
        this.keyboardBacklight = keyboardBacklight;
        this.keyboardWeight = keyboardWeight;
    }

    public String getKeyboardInfo() {
        return keyboardType.getType() + keyboardBacklight.getBacklight();
    }

    public double getKeyboardWeight() {
        return keyboardWeight;
    }
}
