package greetings;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;


public class HelloWorld {

	public static void main(String[] args)
	{
		AsynchronousPrint print = new AsynchronousPrint();
		//Thread thread = new Thread(print);
		
		//thread.start();
		
		ExecutorService executor = Executors.newFixedThreadPool(3);
		
		executor.submit(print);
		executor.submit(print);
		
		executor.shutdown();
		
		for (int i = 0; i < 100; i++) 
		{
			System.out.println("Main Thread " + i);
		}
		
		
		
		
		
		/*
		Printer<ColorCartridge> printer  = new Printer<ColorCartridge>(true, "MY PRINTER", ColorCartridge.RED);
		
		printer.loadPaper(5);
		
				
		//printer.print(3);
		
		PrintingDevice annotation = printer.getClass().getAnnotation(PrintingDevice.class);
		
		try 
		{
			Method method = printer.getClass().getMethod(annotation.defaultPrintMethod(), int.class);
			
			method.invoke(printer, annotation.defaultNumberOfCopys());
		} 
		catch (NoSuchMethodException | SecurityException e) 
		{
			e.printStackTrace();
		}
		catch (IllegalAccessException | IllegalArgumentException | InvocationTargetException e) 
		{
			e.printStackTrace();
		}
		
		printer.outputPage(2);	
		//printer.printColors();
		
//		String filePath = "";
//		
//		Path path = Paths.get(filePath);
//		
//		//Creating a File		
//		try 
//		{
//			Files.createFile(path);			
//		} catch (IOException e) 
//		{
//			e.printStackTrace();
//		}
//		
//		// Delete File		
//		try
//		{
////			if (Files.exists(path))
////			{
////				Files.delete(path);
////			}
//			//or
//			
//			Files.deleteIfExists(path);
//			
//		}
//		catch(IOException ex)
//		{
//			ex.getStackTrace();
//		}
//		
//		//Rename File		
//		try
//		{
//			Files.move(path, Paths.get(""));
//		}
//		catch (IOException ex)
//		{
//			ex.getStackTrace();
//		}		
		
		*/	
	}
	
	
}
