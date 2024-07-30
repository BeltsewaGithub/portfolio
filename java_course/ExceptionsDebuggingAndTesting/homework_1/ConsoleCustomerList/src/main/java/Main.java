//import org.apache.log4j.*;
import org.apache.logging.log4j.*;

import java.util.Scanner;

public class Main {
    private static final String ADD_COMMAND = "add Василий Петров " +
            "vasily.petrov@gmail.com +79215637722";
    private static final String COMMAND_EXAMPLES = "\t" + ADD_COMMAND + "\n" +
            "\tlist\n\tcount\n\tremove Василий Петров";
    private static final String COMMAND_ERROR = "Wrong command! Available command examples: \n" +
            COMMAND_EXAMPLES;
    private static final String HELP_TEXT = "Command examples:\n" + COMMAND_EXAMPLES;
    private static Logger logger;

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        CustomerStorage executor = new CustomerStorage();
        logger = LogManager.getRootLogger();

        while (true) {
            String command = scanner.nextLine();
            String[] tokens = command.split("\\s+", 2);

            logger.log(Level.INFO, command);

            if (tokens[0].equals("add")) {
                try {
                    executor.addCustomer(tokens[1]);
                } catch (Exception ex) {
                    logger.log(Level.ERROR, ex.getMessage() + ": " + command);
                }
            } else if (tokens[0].equals("list")) {
                executor.listCustomers();
            } else if (tokens[0].equals("remove")) {
                executor.removeCustomer(tokens[1]);
            } else if (tokens[0].equals("count")) {
                System.out.println("There are " + executor.getCount() + " customers");
            } else if (tokens[0].equals("help")) {
                System.out.println(HELP_TEXT);
            } else {
                System.out.println(COMMAND_ERROR);
                logger.log(Level.ERROR, "Wrong command: " + command);
            }
        }
    }
}
