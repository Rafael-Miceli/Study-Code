import java.util.ArrayList;
import java.util.List;

/**
 * Created with IntelliJ IDEA.
 * User: Rafael
 * Date: 08/04/14
 * Time: 21:05
 * To change this template use File | Settings | File Templates.
 */
public class Tool {

    public String Name;
    public String toolCategoryName;


    public List<Tool> getToolsFromCategory(String categoryName)
    {
        ToolRepository toolRepository = new ToolRepository();
        List<Tool> allTools = toolRepository.getAllTools();

        List<Tool> toolsFromCategory = new ArrayList<Tool>();
        for (Tool tool : allTools)
            if (tool.toolCategoryName == categoryName)
                toolsFromCategory.add(tool);

        return toolsFromCategory;
    }
}
