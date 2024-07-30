package CompanyInfo;

public class Manager extends AbstractEmployee {
    @Override
    public double getMonthSalary(Company company) {
        if (salary == 0) {
            double fixedPart = generateFixedPartOfSalary(30_000, 65_000);
            salary = ( fixedPart + 0.05*company.getCompanyIncome() );
        }
        return salary;
    }
}
