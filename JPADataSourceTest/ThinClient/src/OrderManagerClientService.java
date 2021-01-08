package shopping.api;

import shopping.*;
import java.net.*;
import java.rmi.*;
import java.util.*;
import javax.ws.rs.*;
import javax.ws.rs.core.*;

@Path("/orders")
public class OrderManagerClientService {

	@Path("/now")
	@GET
	@Produces(MediaType.TEXT_PLAIN)
	public String getTime() {
		return new Date().toString();
	}

	@Path("/{id}")
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	public Response readOrders(@PathParam("id") String customerId) {
		try{
			OrderManager service = (OrderManager)Naming.lookup("rmi://localhost:2099/orderManager");
			List<OrderEntity> result = service.getOrdersOf(customerId);
			if(result.size() == 0)
				return Response.status(404).build();
			return Response.ok(result).build();
		}catch(Exception e){
			return Response.serverError().entity(e.getMessage()).type("text/plain").build();
		}
	}

	@POST
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public Response createOrder(OrderEntity input){
		try{
			OrderManager service = (OrderManager)Naming.lookup("rmi://localhost:2099/orderManager");
			int orderNo = service.placeOrder(input.getCustomerId(), input.getProductNo(), input.getQuantity());
			input.setOrderNo(orderNo);
			URI location = new URI(String.valueOf(orderNo));
			return Response.created(location).entity(input).build();
		}catch(IllegalArgumentException e){
			return Response.status(400).entity(e.getMessage()).type("text/plain").build();
		}catch(Exception e){
			return Response.serverError().entity(e.getMessage()).type("text/plain").build();
		}
		
	}
}


