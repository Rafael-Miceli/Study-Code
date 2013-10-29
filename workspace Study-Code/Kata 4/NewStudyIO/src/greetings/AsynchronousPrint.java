package greetings;

public class AsynchronousPrint implements Runnable 
{

	@Override
	public void run() {
		for (int i = 0; i < 100; i++) 
		{
			System.out.println("Inner Thread " + i);
		}
		
	}

}
