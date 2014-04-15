package App;

import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;

public class ToolTest {
    @Test
    public void test_GetToolsFromCategory() {
        //Arrange
        String category = "Antena";
        Tool tool = new Tool("Nome", "Categoria", new FakeToolRepository());

        //Act
        List<Tool> tools = tool.getToolsFromCategory(category);

        //Assert
        Assert.assertTrue(allToolsAreFromCategory(category, tools));
    }

    private boolean allToolsAreFromCategory(String category, List<Tool> tools) {

        for (Tool tool : tools)
            if (tool.ToolCategoryName != category)
                return false;

        return tools.size() > 0;
    }

}

class FakeToolRepository implements IToolRepository
{
    @Override
    public List<Tool> getAllTools() {
        List<Tool> tools = new ArrayList<Tool>();
        tools.add(new Tool("Nome 1", "Camera"));
        tools.add(new Tool("Nome 2", "Antena"));
        tools.add(new Tool("Nome 3", "Camera"));
        tools.add(new Tool("Nome 4", "Antena"));
        tools.add(new Tool("Nome 5", "Camera"));
        tools.add(new Tool("Nome 6", "Antena"));
        return tools;
    }
}