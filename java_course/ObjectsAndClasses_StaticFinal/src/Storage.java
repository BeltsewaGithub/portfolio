public class Storage {
    private final StorageType storageType;
    private final int storageAmount; //в Гб
    private final double storageWeight;

    public Storage(StorageType storageType, int storageAmount, double storageWeight) {
        this.storageType = storageType;
        this.storageAmount = storageAmount;
        this.storageWeight = storageWeight;
    }

    public String getStorageInfo() {
        return storageType.getStorageType() +
                ", объем " + storageAmount + " Гб";
    }

    public double getStorageWeight() {
        return storageWeight;
    }
}
