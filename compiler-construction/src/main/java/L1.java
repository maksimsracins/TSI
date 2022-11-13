import java.util.LinkedList;
import java.util.Locale;
import java.util.regex.Pattern;


public class L1 {

    private LinkedList<String> listOfEachCodeValue = new LinkedList<>();

    public LinkedList<String> getListOfEachCodeValue() {
        return listOfEachCodeValue;
    }

    public void setListOfEachCodeValue(LinkedList<String> listOfEachCodeValue) {
        this.listOfEachCodeValue = listOfEachCodeValue;
    }

    public LinkedList<String> execute() {

        String code =
                "for I:=1 to 2 do " +
                        "P:=New ();";

        LinkedList<String> listOfNamings = new LinkedList<>();

        StringBuffer victim = new StringBuffer();
        StringBuffer separator = new StringBuffer();

        for (int i = 0; i < code.length(); i++) {
            if(isDigit(code.charAt(i))){
                do{
                    victim.append(code.charAt(i));
                    if (i+1 == code.length()){
                        System.out.println("Lexeme error occurred due to: " + victim + ". Program is over");
                        System.exit(1);
                    }
                    i++;
                }
                while (!isSingleSeparator(code.charAt(i)));
                if(victim.toString().matches(".*[a-zA-z].*")){
                    System.out.println("Error -> " + victim);
                } else if (isSpace(code.charAt(i)) || isSingleSeparator(code.charAt(i))) {
                    System.out.println("Integer constant -> " + victim);
                    listOfEachCodeValue.add(victim.toString());
                    victim = new StringBuffer();
                    listOfNamings.add("Integer constant");
                }
                else
                    System.out.println("Error -> " + victim);
            }

            if (isLetter(code.charAt(i))) {
                do {
                    victim.append(code.charAt(i));
                    if (i+1 == code.length()){
                        System.out.println("Lexeme error occurred due to: " + victim + ". Program is over");
                        System.exit(1);
                    }
                    i++;
                }
                while (isLetter(code.charAt(i)) || isDigit(code.charAt(i)));

                if (isKeyWord(victim.toString())) {
                    System.out.println("Keyword -> " + victim);
                    listOfNamings.add("Keyword");
                    listOfEachCodeValue.add(victim.toString());
                }
                else {
                    System.out.println("ID -> " + victim);
                    listOfNamings.add("ID");
                    listOfEachCodeValue.add(victim.toString());
                }
                victim = new StringBuffer();
            }
            if (isSingleSeparator(code.charAt(i))) {
                separator.append(code.charAt(i));
                if(separator.toString().equals("'")){
                    System.out.println("Single separator -> " + separator);
                    listOfNamings.add("Single separator");
                    if(separator.charAt(0) == ','){
                        listOfEachCodeValue.add("coma");
                    }else
                        listOfEachCodeValue.add(separator.toString());
                    separator = new StringBuffer();
                    i++;
                    do{
                        victim.append(code.charAt(i));
                        i++;
                    } while (code.charAt(i) != '\'' || code.endsWith(" "));
                    if (code.charAt(i) == '\''){
                        separator.append(code.charAt(i));
                        System.out.println("String constant -> " + victim);
                        listOfNamings.add("String constant");
                        listOfEachCodeValue.add(victim.toString());
                    }
                }
                if(code.charAt(i) == '.' || code.charAt(i) == ':'){
                    if (isDoubleSeparator(code.charAt(i), code.charAt(i + 1))) {
                        separator.append(code.charAt(i + 1));
                        System.out.println("Double separator -> " + separator);
                        listOfNamings.add("Double separator");
                        listOfEachCodeValue.add(separator.toString());
                        i++;
                        separator = new StringBuffer();
                    } else if (isSingleSeparator(separator.charAt(0))) {
                        System.out.println("Single separator -> " + separator);
                        listOfNamings.add("Single separator");
                        if(separator.charAt(0) == ',') {
                            listOfEachCodeValue.add("coma");
                        }else
                            listOfEachCodeValue.add(separator.toString());
                        separator = new StringBuffer();
                    }
                    else {
                        System.out.println("Error! Unrecognized symbol ->" + code.charAt(i));
                    }
                }
                if (isSpace(code.charAt(i)) || separator.isEmpty()){
                    separator = new StringBuffer();
                }
                else if(isSingleSeparator(separator.charAt(0)))  {
                    System.out.println("Single separator -> " + separator);
                    listOfNamings.add("Single separator");
                    if(separator.charAt(0) == ','){
                        listOfEachCodeValue.add("coma");
                    }else
                        listOfEachCodeValue.add(separator.toString());
                } else
                    System.out.println("Error! Unrecognized symbol ->" + code.charAt(i));
            } else
                System.out.println("Error! Unrecognized symbol -> " + code.charAt(i));
            victim = new StringBuffer();
            separator = new StringBuffer();
        }
        return listOfNamings;
    }
    private static boolean isSingleSeparator(Character ch) {
        Character[] singleSeparator = {
                '/',',', '.', ':', '[', ']', '\'', '-', '^', '@', ';', '(', ')', '<', '#', ' ', '=', '\t', '\n', '\f', '\r'
        };
        for (int i = 0; i < singleSeparator.length; i++) {
            if (ch == singleSeparator[i]) {
                return true;
            }
        }
        return false;
    }

    private static boolean isKeyWord(String word) {
        String[] keywords = {
                "constructor", "const", "array", "of", "var", "Begin",
                "inherited", "for", "and", "not", "end", "Integer", "or", "to", "New", "do"
        };
        for (int i = 0; i < keywords.length; i++) {
            if (word.equals(keywords[i])) {
                return true;
            }
        }
        return false;
    }

    private static boolean isLetter(Character symbol) {
        if (Pattern.matches("[a-z][a-z]*", symbol.toString().toLowerCase(Locale.ROOT))) {
            return true;
        }
        return false;
    }

    private static boolean isDigit(Character symbol) {
        if (Pattern.matches("[0-9]*", symbol.toString())) {
            return true;
        }
        return false;
    }

    private static boolean isConstant(String word) {
        if (Pattern.matches("\\d+", word)) {
            return true;
        }
        return false;
    }

    private static boolean isSpace(Character space) {
        if (space == ' ' || space == '\t' || space == '\n') {
            return true;
        }
        return false;
    }

    private static boolean isDoubleSeparator(Character firstCh, Character secondCh) {
        if (firstCh == '.' && secondCh == '.' || firstCh == ':' && secondCh == '=') {
            return true;
        }
        return false;
    }
}