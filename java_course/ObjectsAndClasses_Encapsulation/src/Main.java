import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
//        Elevator elevator = new Elevator(-3, 26);
//        while (true) {
//            System.out.print("Введите номер этажа: ");
//            int floor = new Scanner(System.in).nextInt();
//            elevator.move(floor);
//        }

        Dimensions box1 = new Dimensions(20, 20, 20);
        CourierDeliveries vasyaOrder = new CourierDeliveries(2.3, box1, "Lermontova 1b",
                "111", "Fragile", "Don't turn it over");
        vasyaOrder.printInfo("Vasya's order");
        box1.setWidth(15);

        Dimensions box2 = new Dimensions(15, 10, 10);
        CourierDeliveries maryOrder = new CourierDeliveries(3, box2, "Puskina 13",
                "112", "", "");
        maryOrder.printInfo("Mary's order");
        maryOrder.setDimensions(box1);
        maryOrder.printInfo("Mary's order");
        maryOrder = maryOrder.setDimensions(box1);
        maryOrder.printInfo("Mary's order copy");
    }
}
