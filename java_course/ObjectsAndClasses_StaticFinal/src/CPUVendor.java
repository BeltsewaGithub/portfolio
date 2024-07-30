public enum CPUVendor {
    AMD ("AMD"),
    Intel("Intel");

    private String CPUVendor;
    CPUVendor(String CPUVendor) {
        this.CPUVendor = CPUVendor;
    }
    public String getCPUVendor(){
        return CPUVendor;
    }
}
