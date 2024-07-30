package Exceptions;

public class InvalidPhoneAndEmailException extends Exception {
    public InvalidPhoneAndEmailException(String message) {
        super(message);
    }
}
