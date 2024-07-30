public class Main {
    public static void main(String[] args) {
        CPU CPU1 = new CPU(3.2, 4, CPUVendor.Intel, 40);
        Keyboard keyboard1 = new Keyboard(KeyboardType.MEMBRANE, KeyboardBacklight.NO, 300);
        RAM RAM1 = new RAM(RAMType.DDR3, 512,30);
        Screen screen1 = new Screen(19, ScreenType.IPS, 2000);
        Storage storage1 = new Storage(StorageType.HDD, 500, 300);
        CPU CPU2 = new CPU(4, 9, CPUVendor.Intel, 40);
        Screen screen2 = new Screen(22, ScreenType.VA, 1500);

        Computer myComputer = new Computer("Lenovo F", "Lenovo", CPU1, RAM1, storage1, screen1,keyboard1);
        System.out.println(myComputer.toString());
        myComputer.setCPU(CPU2);
        System.out.println(myComputer.toString());
        System.out.println(myComputer.getKeyboard());
        Computer maryComputer = new Computer("Asus SuperGamer100500", "Asus", CPU1, RAM1, storage1, screen2,keyboard1);
        System.out.println(maryComputer.toString());
        System.out.println(maryComputer.getTotalWeight());

    }
}