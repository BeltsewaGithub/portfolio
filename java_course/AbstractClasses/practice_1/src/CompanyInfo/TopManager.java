package CompanyInfo;

public class TopManager extends AbstractEmployee{
    @Override
    public double getMonthSalary(Company company) {
        if (salary == 0) {
            double fixedPart = generateFixedPartOfSalary(85_000, 150_000);
            salary = ( fixedPart + ( (company.getCompanyIncome() > 10_000_000) ? 1.5*fixedPart : 0 ) );
        }
        return salary;
    }
}
