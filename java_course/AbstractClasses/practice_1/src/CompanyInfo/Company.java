package CompanyInfo;

import java.util.*;

public class Company {
    private ArrayList<Employee> employeeList = new ArrayList<>();
    private double companyIncome;

     public Company (double companyIncome) {
         this.companyIncome = companyIncome;
     }

    public double getCompanyIncome() {
        return companyIncome;
    }

    public void hire(Employee employee) {
        employeeList.add(employee);
    }

    public void hireAll(Collection<Employee> employeeList) {
        employeeList.addAll(employeeList);
    }

    public void fire(Employee employee) {
        employeeList.remove(employee);
    }

    public List<Employee> getTopSalaryStaff(int count) {
        List<Employee> salaryList = getSortedEmployeeList();
        Collections.reverse(salaryList);
        List<Employee> topSalaryStaff = getSalaryStaff(count, salaryList);
        return topSalaryStaff;
    }

    public List<Employee> getLowestSalaryStaff(int count) {
        List<Employee> salaryList = getSortedEmployeeList();
        List<Employee> lowestSalaryStaff = getSalaryStaff(count, salaryList);
        Collections.reverse(lowestSalaryStaff);
        return lowestSalaryStaff;
    }

    private List<Employee> getSalaryStaff(int count, List<Employee> employeeList) {
         List<Employee> salaryStaff = new ArrayList<>();
         if (employeeList.size() <= count) {
             return employeeList;
         } else if (count <= 0) {
             return new ArrayList<>();
         } else {
             for (int i = 0; i < count; i++) {
                 salaryStaff.add(employeeList.get(i));
             }
             return salaryStaff;
         }
     }

    private List<Employee> getSortedEmployeeList() {
        List<Employee> sortedEmployeeList = new ArrayList<>();
        List<Double> salaryList = new ArrayList<>();

        for (Employee employee : employeeList) {
            double salary = employee.getMonthSalary(this);
            if (!salaryList.contains(salary)) {
                salaryList.add(salary);
                sortedEmployeeList.add(employee);
            }
        }
        EmployeeComparator comparator = new EmployeeComparator(this);
        Collections.sort(sortedEmployeeList, comparator);
        return sortedEmployeeList;
    }

    public String print(List<Employee> list, String title) {
        String itog = title + "\n\n";
        for (Employee employee : list) {
            itog += employee.getMonthSalary(this) + " руб." + "\n";
        }
        return itog;
    }
}
