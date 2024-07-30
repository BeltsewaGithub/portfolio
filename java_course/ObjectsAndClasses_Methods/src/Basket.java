public class Basket {

    private static int countAllBaskets = 0;
    public static int countAllItems;
    public static double totalCostOfAllItems;
    private String items = "";
    private int totalPrice = 0;
    private int limit;
    private double totalWeigh = 0;
    public static int getCountAllItems() {
        return countAllItems;
    }
    public static double getTotalCostOfAllItems() {
        return totalCostOfAllItems;
    }
    public static double getAverageCostOfAllItems () {
        return totalCostOfAllItems/countAllItems;
    }
    public static double getAverageCostOfTheBasket () {
        return totalCostOfAllItems/ countAllBaskets;
    }
    public Basket() {
        increaseCount(1);
        items = "Список товаров:";
        this.limit = 1000000;
    }

    public Basket(int limit) {
        this();
        this.limit = limit;
    }

    public Basket(String items, int totalPrice, double totalWeigh) {
        this();
        this.items += items;
        this.totalPrice = totalPrice;
        this.totalWeigh = totalWeigh;
    }

    public static int getCountAllBaskets() {
        return countAllBaskets;
    }

    public static void increaseCount(int count) {
        Basket.countAllBaskets += count;
    }

    public void add(String name, int price, double weight) {
        add(name, price, 1, weight);
    }

    public void add(String name, int price, int count) {
        add(name, price, count, 0);
    }
    public void add(String name, int price, int count, double weight) {
        countAllItems += count;
        totalCostOfAllItems += price*count;

        boolean error = false;
        if (contains(name)) {
            error = true;
        }

        if (totalPrice + count * price >= limit) {
            error = true;
        }

        if (error) {
            System.out.println("Error occured :(");
            return;
        }

        items = items + "\n" + name + " - " +
                count + " шт. - " +
                price + " руб./шт.  " +
                weight + " гр./шт.";
        totalPrice += count * price;
        totalWeigh += count * weight;
    }

    public void clear() {
        items = "";
        totalPrice = 0;
        totalWeigh = 0;
    }

    public int getTotalPrice() {
        return totalPrice;
    }

    public double getTotalWeigh() {
        return totalWeigh;
    }

    public boolean contains(String name) { //contains() - метод джава д/проверки наличия подстрок в строке
        return items.contains(name);
    }

    public void print(String title) { //isEmpty() - метод джава д/проверки наличия элементов в списке
        System.out.println(title);
        if (items.isEmpty()) {
            System.out.println("Корзина пуста");
        } else {
            System.out.println(items);
        }
        System.out.println("Общая цена: " + totalPrice + ", общий вес: " + totalWeigh);
    }
}

