import java.util.*;

public class Main {

    private static final String STAFF_TXT = "D:/java_basics/AdvancedOOPFeatures/homework_2/Employees/data/staff.txt";

    public static void main(String[] args) {
        List<Employee> staff = Employee.loadStaffFromFile(STAFF_TXT);
        Employee employeeMaxSalary = findEmployeeWithHighestSalary(staff, 2017);
        System.out.println(employeeMaxSalary);

    }

    public static Employee findEmployeeWithHighestSalary(List<Employee> staff, int year) {
        List<Employee> workedSinceYear = new ArrayList<>();
        year = 2017;
        Date date1 = new Date(year - 1901, 11, 31);
        Date date2 = new Date(year - 1899, 0, 1);

        staff.stream().filter( employee -> (employee.getWorkStart().before(date2) && employee.getWorkStart().after(date1)) )
                .forEach(workedSinceYear::add);
        Collections.sort(workedSinceYear, new Comparator<Employee>() {
            @Override
            public int compare(Employee o1, Employee o2) {
                return -o1.getSalary().compareTo(o2.getSalary());
            }
        });

        return workedSinceYear.get(0);
    }
}