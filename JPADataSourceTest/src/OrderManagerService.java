package shopping;

import java.rmi.RemoteException;
import java.util.*;
import javax.persistence.*;

public class OrderManagerService extends java.rmi.server.UnicastRemoteObject implements OrderManager {

	public OrderManagerService(int port) throws RemoteException {
		super(port);
	}

	public int placeOrder(String customerId, int productNo, int quantity) throws RemoteException {
		var emf = Persistence.createEntityManagerFactory("SalesPU");
		var em = emf.createEntityManager();
		var tx = em.getTransaction();
		tx.begin(); //will automatically rollback on exception
		try{
			var ctr = em.find(CounterEntity.class, "orders");
			int orderNo = ctr.getNextValue() + 1000;
			var ord = new OrderEntity(orderNo, customerId, productNo, quantity);
			em.persist(ord);
			tx.commit();
			return orderNo;
		}catch(RollbackException e){
			String err = e.getMessage();
			if(err.contains("FK_ORDERS_CUSTOMERS"))
				throw new IllegalArgumentException("Invalid Customer ID");
			else if(err.contains("FK_ORDERS_PRODUCTS"))
				throw new IllegalArgumentException("Invalid Product No");
			throw new RemoteException(err);
		}finally{
			em.close();
		}
	}

	public List<OrderEntity> getOrdersOf(String customerId) throws RemoteException{
		var emf = Persistence.createEntityManagerFactory("SalesPU");
		var em = emf.createEntityManager();
		try{
	 		var query = em.createQuery("SELECT e FROM OrderEntity e WHERE e.customerId = ?1 ORDER BY e.orderNo", OrderEntity.class);
			query.setParameter(1, customerId);
			return query.getResultList();
		}finally{
			em.close();
		}
	}
}

