import CompanyInfo.*;

import java.util.*;

public class Main {
    public static void main(String[] args) {
        Company company = new Company(generateCompanyIncome(115_000, 140_000));
        for (int i = 0; i < 180; i++) {
            company.hire(new Operator());
        }
        for (int i = 0; i < 80; i++) {
            company.hire(new Manager());
        }
        for (int i = 0; i < 10; i++) {
            company.hire(new TopManager());
        }

        List<Employee> topSalaryList = company.getTopSalaryStaff(3);
        List<Employee> lowestSalaryList = company.getLowestSalaryStaff(4);
        System.out.println(company.print(topSalaryList, "Наивысшие зарплаты по убыванию:"));
        System.out.println(company.print(lowestSalaryList, "Низшие зарплаты по убыванию:"));

    }

    public static double generateCompanyIncome(double min, double max) {
        double x = (int) (Math.random() * ((max - min) + 1)) + min;
        return x;
    } //generateCompanyIncome(115_000, 140_000)
}
