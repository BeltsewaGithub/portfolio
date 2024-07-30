public class CPU {
    private final double CPUFrequency; // в ГГц
    private final int CPUCores;
    private final CPUVendor CPUVendor;
    private final double CPUWeight; // в граммах

    public CPU(double CPUFrequency, int CPUCores, CPUVendor CPUVendor, double CPUWeight) {
        this.CPUFrequency = CPUFrequency;
        this.CPUCores = CPUCores;
        this.CPUVendor = CPUVendor;
        this.CPUWeight = CPUWeight;
    }

    public String getCPUInfo() {
        return CPUVendor.getCPUVendor() +
                ", количество ядер " + CPUCores +
                ", частота " + CPUFrequency + " ГГц";
    }

    public double getCPUWeight () {
        return CPUWeight;
    }
}
