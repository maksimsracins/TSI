import java.util.LinkedList;

public class L2 {

    static Boolean isDoubleSeparator = false;
    static Boolean isCorrectDoubleSeparator = false;

    public static void main(String[] args) {
        L1 l1 = new L1();
        L2 l2 = new L2();

        LinkedList<String> listOfNamings = l1.execute();
        LinkedList<String> listOfEachCodeValue = l1.getListOfEachCodeValue();

        System.out.println(listOfNamings);
        System.out.println(listOfEachCodeValue);

        l2.parse(listOfNamings, listOfEachCodeValue);

    }

    public void parse(LinkedList<String> listOfNamings, LinkedList<String> listOfValues) {
        int index = 0;

        if(!listOfValues.get(listOfNamings.size()-1).equals(";")){
            lexemError("symbol ; is missing");
        }

        if (listOfValues.get(index).equals("for")) {
            index++;
            if (listOfValues.get(index).equals("I") || listOfNamings.get(index).equals("ID")){
                index++;
            } else
                lexemError("identificator is missing");
            if (isCorrectDoubleSeparator(listOfValues,listOfNamings,index)){
                index++;
            } else if (isDoubleSeparator){
                lexemError("incorrect double separator is provided");
            }
            else
                lexemError("double separator =: is missing");

            if(listOfValues.get(index).equals("0") || listOfNamings.get(index).equals("Integer constant")){
                index++;
            } else
                lexemError("numeric value is missing");

            if (listOfValues.get(index).equals("to")){
                index++;
                if(listOfValues.get(index).equals("19") || listOfNamings.get(index).equals("Integer constant")){
                    index++;
                } else
                    lexemError("numeric value is missing");
            } else if (listOfNamings.get(index).equals("Keyword"))
                lexemError("incorrect keyword is used");
            if(Integer.parseInt(listOfValues.get(3)) > Integer.parseInt(listOfValues.get(5)) ){
                lexemError("loop should be iterated from lower number to higher");
            }

            if (listOfValues.get(index).equals("do")){
                index++;
                if (listOfValues.get(index).equals("P") || listOfNamings.get(index).equals("ID")){
                    index++;
                } else
                    lexemError("identificator is missing");
                if (isCorrectDoubleSeparator(listOfValues,listOfNamings,index)){
                    index++;
                } else if (isDoubleSeparator){
                    lexemError("incorrect double separator is provided");
                } else
                    lexemError("double separator =: is missing");
            } else
                lexemError("keyword DO is missing");
        } else
            lexemError("keyword FOR is missing");
        if (listOfValues.get(index).equals("New")){
            index++;
            if(listOfValues.get(index).equals("(")){
                if (isExistClosingParanthesis(listOfValues,listOfNamings,index)){
                    index++;
                    for (; index < listOfValues.size();index++){
                        if(listOfNamings.get(index).equals("ID")) {
                            index++;
                            if (listOfNamings.get(index + 1).equals("ID")) {
                                if (!listOfValues.get(index).equals("coma"))
                                    lexemError("incorrect parameters value: " + listOfValues.get(index) + ". Separator is missing");
                            } else if (listOfNamings.get(index).equals("Single separator") && !listOfValues.get(index).equals(")"))
                                lexemError("incorrect single separator");
                        }
                        if (listOfValues.get(index).equals(")")){
                            index++;
                            break;
                        }
                    }
                } else
                    lexemError("closing parenthesis is missing");
            }
            if (listOfValues.get(index).equals(";")){
            } else
                lexemError("program is over and some value is used. Please remove: " + listOfValues.get(index+1));
        } else
            lexemError("keyword New is missing");

        System.out.println("Program code is correct.");
}
    public void lexemError(String text){
        System.out.println("Lexeme error occurred due to: " + text);
        System.exit(1);
    }
    public Boolean isCorrectDoubleSeparator(LinkedList<String> listOfValues, LinkedList<String> listOfNamings,  int index){
        if (listOfValues.get(index).equals(":=")) {
            isCorrectDoubleSeparator = true;
        } else if(!listOfValues.get(index).equals(":=") || listOfNamings.get(index).equals("Double separator")) {
            isDoubleSeparator = true;
            isCorrectDoubleSeparator = false;
        } else{
            isDoubleSeparator = false;
        isCorrectDoubleSeparator = false;
    }
        return isCorrectDoubleSeparator;
    }
    public Boolean isExistClosingParanthesis(LinkedList<String> listOfValues, LinkedList<String> listOfNamings,  int index){
        boolean isSecondParanthesisFound = false;
        for(int i=index; i<listOfValues.size();i++){
            if (!listOfValues.get(i).equals(")")){
                isSecondParanthesisFound = false;
            }
            else {
                isSecondParanthesisFound = true;
                break;
            }
        }
        return isSecondParanthesisFound;
    }
}
