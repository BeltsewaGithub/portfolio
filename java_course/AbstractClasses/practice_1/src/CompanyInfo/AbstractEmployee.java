package CompanyInfo;

public abstract class AbstractEmployee implements Employee {
    protected double salary = 0;
    @Override
    public abstract double getMonthSalary(Company company);
    protected double generateFixedPartOfSalary(double min, double max) {
        double x = (int) (Math.random() * ((max - min) + 1)) + min;
        return x;
    }
}
