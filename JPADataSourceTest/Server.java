class Server {

	public static void main(String[] args) throws Exception {
		var ds = new oracle.jdbc.pool.OracleConnectionPoolDataSource();
		ds.setURL("jdbc:oracle:thin:@//localhost/xe");
		ds.setUser("scott");
		ds.setPassword("tiger");
		java.rmi.registry.LocateRegistry.createRegistry(2099);
		System.setProperty("java.naming.factory.initial", "com.sun.jndi.rmi.registry.RegistryContextFactory");
		System.setProperty("java.naming.provider.url", "rmi://localhost:2099");
		var naming = new javax.naming.InitialContext();
		naming.bind("jdbc/SalesDB", ds);
		naming.bind("orderManager", new shopping.OrderManagerService(2099));
	}

}

