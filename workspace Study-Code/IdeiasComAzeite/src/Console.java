/**
 * Created with IntelliJ IDEA.
 * User: Rafael
 * Date: 08/04/14
 * Time: 21:20
 * To change this template use File | Settings | File Templates.
 */
public class Console {

    public static void main(String args[])
    {
        System.out.println("Digite a categoria");
        //Lê categoria

        Tool tools = new Tool();

        System.out.println("Ferramentas da categoria 'Antena'");
        for (Tool tool : tools.getToolsFromCategory("Antena"))
        {
            System.out.println(tool.Name);
        }
    }
}
