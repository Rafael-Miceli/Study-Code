package Main;

import java.util.ArrayList;
import java.util.List;

public class Tool {

    public String Name;
    public String ToolCategoryName;

    public Tool(String name, String toolCategoryName)
    {
        Name = name;
        ToolCategoryName = toolCategoryName;
    }


    public List<Tool> getToolsFromCategory(String categoryName)
    {
        ToolRepository toolRepository = new ToolRepository();
        List<Tool> allTools = toolRepository.getAllTools();

        List<Tool> toolsFromCategory = new ArrayList<Tool>();
        for (Tool tool : allTools)
            if (tool.ToolCategoryName == categoryName)
                toolsFromCategory.add(tool);

        return toolsFromCategory;
    }
}
