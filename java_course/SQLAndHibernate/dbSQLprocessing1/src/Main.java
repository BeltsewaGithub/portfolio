import java.sql.*;

public class Main {
    public static void main(String[] args) {
        String url = "jdbc:mysql://localhost:3306/skillbox";
        String user = "root";
        String pass = "7359";

        try {
            Connection connection = DriverManager.getConnection(url, user, pass);

            Statement statement = connection.createStatement();

            ResultSet coursesSet = statement
                    .executeQuery("SELECT distinct sc.name, (count(*)/(max(month (subscription_date))-min(month (subscription_date)))) as average_sales " +
                            "FROM skillbox.courses as sc " +
                            "INNER JOIN skillbox.subscriptions as ss ON sc.id = ss.course_id " +
                            "where subscription_date > 2018 " +
                            "group by name");

            while (coursesSet.next())
            {
                System.out.println(coursesSet.getString("name") + "|" + coursesSet.getString("average_sales"));
            }

        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }
}