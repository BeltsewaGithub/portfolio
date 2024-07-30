public class Computer {

    private final String name;
    private final String vendor;
    private Computer computer;
    private CPU CPU;
    private RAM RAM;
    private Storage storage;
    private Screen screen;
    private Keyboard keyboard;

    public Computer(String name, String vendor, CPU CPU, RAM RAM, Storage storage, Screen screen, Keyboard keyboard) {
        this.name = name;
        this.vendor = vendor;
        this.CPU = CPU;
        this.RAM = RAM;
        this.storage = storage;
        this.screen = screen;
        this.keyboard = keyboard;
    }

    public double getTotalWeight () {
        return (CPU.getCPUWeight() + RAM.getRAMWeight() + storage.getStorageWeight() +
                screen.getScreenWeight() + keyboard.getKeyboardWeight())/1000;
    }

    public String toString() {
        return "\n\n" + name + "\nПроизводитель - " + vendor +
                "\nЦентральный процессор - " + CPU.getCPUInfo() +
                "\nОперативная память - " + RAM.getRAMInfo() +
                "\nНакопитель информации - " + storage.getStorageInfo() +
                "\nЭкран - " + screen.getScreenInfo() +
                "\nКлавиатура - " + keyboard.getKeyboardInfo() +
                "\n\nВес компьютера " + this.getTotalWeight() + "кг";
    }

    public String getCPU() {
        return "Цетральный процессор " + name + " - " + CPU.getCPUInfo();
    }

    public void setCPU(CPU CPU) {
        this.CPU = CPU;
    }

    public String getRAM() {
        return "Оперативная память " + name + " - " + RAM.getRAMInfo();
    }

    public void setRAM(RAM RAM) {
        this.RAM = RAM;
    }

    public String getStorage() {
        return "Накопитель информации " + name + " - " + storage.getStorageInfo();
    }

    public void setStorage(Storage storage) {
        this.storage = storage;
    }

    public String getScreen() {
        return "Экран " + name + " - " + screen.getScreenInfo();
    }

    public void setScreen(Screen screen) {
        this.screen = screen;
    }

    public String getKeyboard() {
        return "Клавиатура " + name + " - " + keyboard.getKeyboardInfo();
    }

    public void setKeyboard(Keyboard keyboard) {
        this.keyboard = keyboard;
    }
}
