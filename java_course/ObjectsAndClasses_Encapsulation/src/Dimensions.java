public class Dimensions {

    private final double height;
    private final double length;
    private final double width;
    public Dimensions (double height, double length, double width) {
        this.height = height;
        this.length = length;
        this.width = width;
    }

    public Dimensions setHeight (double height) {
        return new Dimensions(height, length, width);
    }
    public Dimensions setLength (double length) {
        return new Dimensions(height, length, width);
    }
    public Dimensions setWidth (double width) {
        return new Dimensions(height, length, width);
    }
    public String getVolume () {
        return (height*length*width)/1000000 + " м^3";
    }
}
