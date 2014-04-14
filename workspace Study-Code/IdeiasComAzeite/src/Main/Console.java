package Main;

public class Console {

    public static void main(String args[])
    {
        System.out.println("Digite a categoria");
        //Lê categoria

        Tool tools = new Tool("Ferramenta", "Teste");

        System.out.println("Ferramentas da categoria 'Antena'");
        for (Tool tool : tools.getToolsFromCategory("Antena"))
        {
            System.out.println(tool.Name);
        }
    }
}
