public class Main {
    public static void main(String[] args) {
        Container container = new Container();
        container.addCount(5672);
        System.out.println(container.getCount());

//         TODO: ниже напишите код для выполнения задания:
//          С помощью цикла и преобразования чисел в символы найдите все коды
//          букв русского алфавита — заглавных и строчных, в том числе буквы Ё.

        char firstCyrillicLetter = 'А';
        char lastCyrillicLetter = 'я';
        char necessaryLetterUpper = 'Ё';
        char necessaryLetterLower = 'ё';
        int numberOfCyrillicLetters = 66;
        int numOfFoundLetters = 0;

        for (int i = 0; i < 65536; i++) {
            char c = (char) i;
            if ((c >= firstCyrillicLetter && c <= lastCyrillicLetter) || c == necessaryLetterLower || c == necessaryLetterUpper) {
                numOfFoundLetters++;
                System.out.println(c + " - " + i);
            }
        }

        if (numOfFoundLetters == numberOfCyrillicLetters) {
            System.out.println("\nThat's all chars of the Russian alphabet");
        }
    }
}
