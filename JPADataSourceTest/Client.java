class Client {

	public static void main(String[] args) throws Exception {
		var service = (shopping.OrderManager)java.rmi.Naming.lookup("rmi://localhost:2099/orderManager");
		String customerId = args[0].toUpperCase();
		if(args.length > 2){
			int productNo = Integer.parseInt(args[1]);
			int quantity = Integer.parseInt(args[2]);
			try{
				int orderNo = service.placeOrder(customerId, productNo, quantity);
				System.out.printf("New Order Number: %d%n", orderNo);
			}catch(IllegalArgumentException e){
				System.out.printf("Order Failed: %s%n", e.getMessage());
			}
		}else{
			for(var entry : service.getOrdersOf(customerId)){
				System.out.printf("%tF\t%d\t%d%n", entry.getOrderDate(), entry.getProductNo(), entry.getQuantity());
			}
		}
	}
}

