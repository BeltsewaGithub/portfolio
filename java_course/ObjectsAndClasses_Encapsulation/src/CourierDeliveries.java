public class CourierDeliveries {
    private final double weight;
    private final Dimensions dimensions;
    private final String address;
    private final String regNumber;
    private final String isFragileGoods;
    private final String isPossibleToTurnOver;

    public CourierDeliveries(double weight, Dimensions dimensions, String address,
                             String regNumber, String isFragileGoods, String isPossibleToTurnOver) {
        this.weight = weight;
        this.dimensions = dimensions;
        this.address = address;
        this.regNumber = regNumber;
        this.isFragileGoods = isFragileGoods;
        this.isPossibleToTurnOver = isPossibleToTurnOver;
    }


    public CourierDeliveries setAddress(String address) {
        return new CourierDeliveries(weight, dimensions, address,
                regNumber, isFragileGoods, isPossibleToTurnOver);
    }

    public CourierDeliveries setDimensions(Dimensions dimensions) {
        return new CourierDeliveries(weight, dimensions, address,
                regNumber, isFragileGoods, isPossibleToTurnOver);
    }

    public CourierDeliveries setWeight(double weight) {
        return new CourierDeliveries(weight, dimensions, address,
                regNumber, isFragileGoods, isPossibleToTurnOver);
    }

    public void printInfo(String title) {
        System.out.println(title);
        String properties = isFragileGoods + isPossibleToTurnOver;
        if (!properties.isEmpty()) {
            properties = isFragileGoods + " " + isPossibleToTurnOver;
        } else {
            properties = "-";
        }
        System.out.println("Объем " + dimensions.getVolume() +
                ", Вес " + weight + " кг" +
                ", Адрес доставки " + address +
                ", Регистрационный номер " + regNumber +
                ", Особые свойства: " + properties);
    }
}

