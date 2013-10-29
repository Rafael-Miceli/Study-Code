package printing;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.HashMap;
import java.util.Map;

@PrintingDevice(defaultPrintMethod = "print", defaultNumberOfCopys = 2)
public class Printer<T extends ICartridge> implements IMachine 
{
	private String modelNumber;
	private PaperTray paperTray = new PaperTray();
	private Machine machine;
	private T cartridge;
	//private List<Page> pages = new ArrayList<Page>();
	private Map<Integer, Page> pagesMap = new HashMap<Integer, Page>();
	
	public Printer(boolean isOn, String modelNumber, T cartridge)
	{
		machine = new Machine(isOn);
		this.modelNumber = modelNumber;
		this.cartridge = cartridge;
	}
	
	@Override
	public void TurnOn()
	{
		System.out.println("Warming up printer");
		machine.TurnOn();
	}
	
	public <U extends ICartridge> void printUsingCartridge(U cartridge, String message)
	{
		System.out.println(cartridge.toString());
		System.out.println(message);
		System.out.println(cartridge.toString());
	}
	
	
	public void print(int copies)
	{					
		String onStatus = "";
		if(machine.isOn())
			onStatus = " is On!";
		else
			onStatus = " is Off!";
		
		String textToPrint = getTextFromFile(); //modelNumber + onStatus;
		//textToPrint += "|||" + cartridge.printColor() + "|||"; 
		int pageNumber = 1;
						
		while( copies > 0 && !paperTray.isEmpty() )
		{
			pagesMap.put(pageNumber, new Page(textToPrint + ":" + pageNumber));
			
			copies--;
			pageNumber++;
			paperTray.usePage();
		}
		
		if(paperTray.isEmpty())
			System.out.println("Load more paper!");
	}
	
	private String getTextFromFile() 
	{
		String text= "", file = "D:\\teste.txt";
		FileReader reader = null;
		BufferedReader breader = null;		
		CapitalizationReader capReader = null;
		
		try
		{		
			reader = new FileReader(file);
			breader = new BufferedReader(reader);
			capReader = new CapitalizationReader(breader);
			
			String line; 
			while((line = capReader.readLine()) != null)
			{
				text += line + "\n";
			}
			
			return text;
			//int c;
			//while((c = reader.read()) != -1)
			//{
				
			//}
		}
		catch (FileNotFoundException ex)
		{			
			ex.printStackTrace();
		}
		catch (IOException e) 
		{
			e.printStackTrace();
		}
		finally
		{
			if(capReader != null)
				try {
					capReader.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
		}
		return "";
	}

	public void outputPage(int pageNumber)
	{
		String file = "D:\\out.txt";
		PrintWriter writer = null;
		FileWriter fWriter;
		try
		{
			fWriter = new FileWriter(file);
			writer = new PrintWriter(fWriter);
			
			writer.println(pagesMap.get(pageNumber).getText());
		}
		catch(IOException ex)
		{
			ex.getStackTrace();
		}
		finally
		{
			if(writer != null)
				writer.close();
		}
		
		//System.out.println(pagesMap.get(pageNumber).getText());
	}

	private void checkCopies(int copies) {
		if(copies < 0)
			throw new IllegalArgumentException("Can't print less than 0 copies.");
	}
	
	
	public void printColors()
	{
		String[] colors = new String[] { "Red", "Blue", "Green", "Yellow", "Orange" };
		
		for( String currentColor : colors )
		{
			if("Green".equals(currentColor))
				continue;
			
			System.out.println(currentColor);
		}
		
	}
	
	private void print(String text)
	{
		System.out.println(text);
	}
	
	public String getModelNumber()
	{
		return modelNumber;
	}
	
	public T getCartridge()
	{
		return cartridge;
	}

	public void loadPaper(int count) 
	{
		paperTray.addPaper(count);
	}

	@Override
	public void TurnOff() {
		machine.TurnOff();
	}

	@Override
	public boolean isOn() {
		return machine.isOn();
	}
}
