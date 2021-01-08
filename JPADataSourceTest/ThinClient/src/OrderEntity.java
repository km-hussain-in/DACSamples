package shopping;

import java.util.*;

public class OrderEntity implements java.io.Serializable{

	private int orderNo;

	private Date orderDate;

	private String customerId;

	private int productNo;

	private int quantity;

	public OrderEntity(){}

	public OrderEntity(int orderNo, String customerId, int productNo, int quantity){
		this.orderNo = orderNo;
		this.orderDate = new Date();
		this.customerId = customerId;
		this.productNo = productNo;
		this.quantity = quantity;
	}

	public int getOrderNo() {return orderNo;}
	public void setOrderNo(int value) {orderNo = value;}

	public String getCustomerId() {return customerId;}
	public void setCustomerId(String value) {customerId = value;}

	public Date getOrderDate() {return orderDate;}
	public void setOrderDate(Date value) {orderDate = value;}

	public int getProductNo() {return productNo;}
	public void setProductNo(int value) {productNo = value;}

	public int getQuantity() {return quantity;}
	public void setQuantity(int value) {quantity = value;}
}

