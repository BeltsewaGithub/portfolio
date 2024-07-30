public class Screen {
    public final double screenDiagonal; //в дюймах
    public final ScreenType screenType;
    public final double screenWeight;

    public Screen(double screenDiagonalInInch, ScreenType screenType, double screenWeight) {
        this.screenDiagonal = screenDiagonalInInch;
        this.screenType = screenType;
        this.screenWeight = screenWeight;
    }

    public String getScreenInfo() {
        return "диагональ " + screenDiagonal + " дюйма(-ов)" +
                ", тип экрана " + screenType.getScreenType();
    }

    public double getScreenWeight() {
        return screenWeight;
    }
}
