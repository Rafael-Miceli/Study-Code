package App;

import App.Tool;

import java.util.ArrayList;
import java.util.List;

public class ToolRepository implements IToolRepository {

    public List<Tool> getAllTools()
    {
        //Return All Tools From Database
        List<Tool> tools = new ArrayList<Tool>();
        return tools;
    }
}
