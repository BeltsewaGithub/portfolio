public class Main {

    public static void main(String[] args) {
        Basket maryBasket = new Basket();
        maryBasket.add("Молоко", 40, 1);
        maryBasket.add("Масло", 100, 1);
        maryBasket.add("Кефир", 200, 300.0);
        maryBasket.print("\nКорзина Маши: ");
        maryBasket.clear();
        maryBasket.print("\nКорзина Маши: ");

        Basket gregBasket = new Basket();
        gregBasket.add("Хлеб", 65, 1);
        gregBasket.add("Жвачка", 5, 3);
        gregBasket.print("\nКорзина Гриши: ");
        Basket danBasket = new Basket();
        Basket tomBasket = new Basket();
//        Basket.increaseCount(2);
        System.out.println("\nКоличество корзин " + Basket.getCountAllBaskets());
        System.out.println("Общая стоимость товаров " + Basket.getTotalCostOfAllItems());
        System.out.println("Общее количество товаров " + Basket.getCountAllItems());
        System.out.println("Средняя цена товара " + Basket.getAverageCostOfAllItems());
        System.out.println("Средняя стоимость корзины " + Basket.getAverageCostOfTheBasket());

    }
}

