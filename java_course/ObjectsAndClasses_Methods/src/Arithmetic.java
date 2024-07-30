public class Arithmetic {
    public static void main(String[] args) {
        System.out.println(sum(78, 3));
        System.out.println(product(9, 3));
        System.out.println(min(2445, 56756));
        System.out.println(max(76,67));
    }

    private int a;
    private int b;

    public Arithmetic(int a, int b) {
        this.a = a;
        this.b = b;
    }

    public static int sum(int a, int b) {
        return (a + b);
    }

    public static int product(int a, int b) {
        return (a*b);
    }

    public static int min(int a, int b) {
        return (a > b) ? b : a;
    }

    public static int max(int a, int b) {
        return (a < b) ? b : a;
    }
}
