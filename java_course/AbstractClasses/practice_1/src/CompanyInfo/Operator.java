package CompanyInfo;

public class Operator extends AbstractEmployee {
    @Override
    public double getMonthSalary(Company company) {
        if (salary == 0) {
            salary = generateFixedPartOfSalary(25_000, 50_000);
        }
        return salary;
    }
}
