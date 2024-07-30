import java.util.Collections;
import java.util.List;

public class Main {

    public static final String STAFF_TXT = "D:/java_basics/AdvancedOOPFeatures/homework_1/data/staff.txt"; //data/staff.txt

    public static void main(String[] args) {
        List<Employee> staff = Employee.loadStaffFromFile(STAFF_TXT);
        sortBySalaryAndAlphabet(staff);
        System.out.println(staff);
    }

    public static void sortBySalaryAndAlphabet(List<Employee> staff) {
        Collections.sort(staff, (e1, e2) -> {
            if (e1.getSalary().equals(e2.getSalary())) {
                return e1.getName().compareTo(e2.getName());
            } else {
                return e1.getSalary().compareTo(e2.getSalary());
            }
        });
    }
}