package App;

import java.util.ArrayList;
import java.util.List;

public class Tool {

    public String Name;
    public String ToolCategoryName;
    private IToolRepository _toolRepository;

    public Tool(String name, String toolCategoryName){
        Name = name;
        ToolCategoryName = toolCategoryName;
        _toolRepository = new ToolRepository();
    }

    public Tool(String name, String toolCategoryName, IToolRepository toolRepository){
        Name = name;
        ToolCategoryName = toolCategoryName;
        _toolRepository = toolRepository;
    }

    public List<Tool> getToolsFromCategory(String categoryName){
        List<Tool> allTools = _toolRepository.getAllTools();

        List<Tool> toolsFromCategory = new ArrayList<Tool>();
        for (Tool tool : allTools)
            if (tool.ToolCategoryName.equals(categoryName))
                toolsFromCategory.add(tool);

        return toolsFromCategory;
    }

    public void insertToolInDatabase(Tool tool)
    {

    }
}
