package shopping;

public class CounterEntity implements java.io.Serializable{

	private String name;

	private int currentValue;

	public int getNextValue(){
		return ++currentValue;
	}
}


