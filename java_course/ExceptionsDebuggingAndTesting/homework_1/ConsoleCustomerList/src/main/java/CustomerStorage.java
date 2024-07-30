import Exceptions.InvalidEmailException;
import Exceptions.InvalidPhoneAndEmailException;
import Exceptions.InvalidPhoneNumberException;

import java.util.HashMap;
import java.util.Map;

public class CustomerStorage {
    private final Map<String, Customer> storage;

    public CustomerStorage() {
        storage = new HashMap<>();
    }

    public void addCustomer(String data) throws InvalidPhoneNumberException, InvalidEmailException, InvalidPhoneAndEmailException {
        final String EMAIL_ERROR_MESSAGE = "Invalid format of the email";
        final String PHONE_ERROR_MESSAGE = "Invalid format of the phone number";
        final String COMMAND_ERROR = "Invalid format of the command \"add\"";

        final int INDEX_NAME = 0;
        final int INDEX_SURNAME = 1;
        final int INDEX_EMAIL = 2;
        final int INDEX_PHONE = 3;

        final String EMAIL_REGEX = "^[-\\w.]+@([A-z0-9][-A-z0-9]+\\.)+[A-z]{2,4}$";
        final String PHONE_REGEX = "^((\\+7|7|8)+([0-9]){10})$";
        final int REQUIRED_ELEMENTS_NUMBER = 4;

        String[] components = data.split("\\s+");

        final int dataLength = components.length;

        if (dataLength != REQUIRED_ELEMENTS_NUMBER) {
            throw new IllegalArgumentException(COMMAND_ERROR);
        } else if (!components[INDEX_PHONE].matches(PHONE_REGEX) && !components[INDEX_EMAIL].matches(EMAIL_REGEX)) {
            throw new InvalidPhoneAndEmailException(PHONE_ERROR_MESSAGE + "\n" + EMAIL_ERROR_MESSAGE);
        } else if (!components[INDEX_PHONE].matches(PHONE_REGEX)) {
            throw new InvalidPhoneNumberException(PHONE_ERROR_MESSAGE);
        } else if (!components[INDEX_EMAIL].matches(EMAIL_REGEX)) {
            throw new InvalidEmailException(EMAIL_ERROR_MESSAGE);
        } else {
            String name = components[INDEX_NAME] + " " + components[INDEX_SURNAME];
            storage.put(name, new Customer(name, components[INDEX_PHONE], components[INDEX_EMAIL]));
        }
    }

    public void listCustomers() {
        storage.values().forEach(System.out::println);
    }

    public void removeCustomer(String name) {
        storage.remove(name);
    }

    public Customer getCustomer(String name) {
        return storage.get(name);
    }

    public int getCount() {
        return storage.size();
    }
}