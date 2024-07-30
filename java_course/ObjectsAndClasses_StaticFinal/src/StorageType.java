public enum StorageType {
    HDD ("HDD"),
    SSD ("SSD");
    private String storageType;
    StorageType(String storageType) {
        this.storageType = storageType;
    }
    public String getStorageType() {
        return storageType;
    }
}
