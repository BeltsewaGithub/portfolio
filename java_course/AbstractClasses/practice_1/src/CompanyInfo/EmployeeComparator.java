package CompanyInfo;

import java.util.Comparator;

public class EmployeeComparator implements Comparator<Employee> {
    private Company company;
    public EmployeeComparator(Company company) {
        this.company = company;
    }
    @Override
    public int compare(Employee o1, Employee o2) {
        if (o1.getMonthSalary(company) < o2.getMonthSalary(company)) {
            return -1;
        }
        else if (o1.getMonthSalary(company) > o2.getMonthSalary(company)) {
            return 1;
        }
        return 0;
    }
}
