using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postman.Models;
using Postman.DataAccess;
using System.Configuration;
using Dapper;
namespace Postman.Repository
{
    class ParcelRepositry
    {

        CustomerRepostiroy customerRepo = new CustomerRepostiroy();
        public int? createone(Parcel parcel , int userId)
        {
            int customerId = -1;
            var customer = customerRepo.getOneCustomer(parcel.customer.phone);
            if (customer != null) customerId = customer.id;
            else
            {
                customerRepo.CreateCustomer(parcel.customer, userId);
                var customer2 = customerRepo.getOneCustomer(parcel.customer.phone);
                if (customer2 != null) customerId = customer2.id;
            }
            if (customerId < 0) return -1;
            Console.WriteLine(parcel.paymetMethod);
            return ConnectionDB.ExecuteQuery(@"INSERT INTO parcel VALUES
                                                (
                                                    @invoiceNo,
                                                    @paymetMethod,
                                                    @packageWeight,
                                                    @amountToCollect,
                                                    @deliveryFee,
                                                    @parcelStatus,  @customerId,@userId,null,null);",
                new { parcel.invoiceNo, parcel.paymetMethod, parcel.packageWeight, parcel.amountToCollect, parcel.deliveryFee, parcel.parcelStatus,customerId, userId});
        }

        public List<Parcel> getAllUser(int id)
        {
            return ConnectionDB.getConnection().Query<Parcel, Customer, Parcel>(@"SELECT 
		                                                    *
	                                                    FROM parcel P  INNER JOIN customer C on P.customerId=C.id WHERE P.userId=@id;", (b,a) => { b.customer = a; return b; }, new { id }, splitOn: "id").ToList();
        }

        public List<Parcel> getRiderParcel(int id)
        {
            return ConnectionDB.getConnection().Query<Parcel, Customer, Parcel>(@"SELECT 
		                                                    *
	                                                    FROM parcel P  INNER JOIN customer C on P.customerId=C.id WHERE P.riderId=@id;", (b, a) => { b.customer = a; return b; }, new { id }, splitOn: "id").ToList();
        }
        public List<Parcel> getAvaialblePacel(int id)
        {
            return ConnectionDB.getConnection().Query<Parcel, Customer, Parcel>(@"SELECT 
		                                                    *
	                                                    FROM parcel P  INNER JOIN customer C on P.customerId=C.id WHERE P.status='PENDING';", (b, a) => { b.customer = a; return b; }, new { id }, splitOn: "id").ToList();
        }


        public int? AssignParcelToRider(int id, int riderId)
        {
            return  ConnectionDB.ExecuteQuery("UPDATE parcel SET status=@status,riderId=@riderId WHERE id=@id;",
                new {status=DeliveryStatus.ONDELIVERY,riderId, id });
        
        }


        public List<Parcel> getRiderConsignments(int riderId)
        {
            return ConnectionDB.SelectQuery<Parcel>("SELECT * FROM parcel WHERE riderId=@riderId;", new { riderId }).ToList();
        }

        public List<Parcel> getAll()
        {
            return ConnectionDB.SelectQuery<Parcel>("SELECT * FROM parcel;").ToList();
        }

        public Parcel getOneParcel(int id)
        {
            return ConnectionDB.getConnection().Query<Parcel, Customer, Parcel>(@"SELECT 
		                                                    *
	                                                   FROM parcel P  INNER JOIN customer C on P.customerId=C.id WHERE P.id=@id", (b, a) => { b.customer = a; return b; }, new { id }, splitOn: "id").SingleOrDefault();
        }
        public int? updateOne(int id, Parcel parcel)
        {
            return ConnectionDB.ExecuteQuery(@"UPDATE parcel 
		                                        SET invoiceNo=@invoiceNo,
			                                        method=@method',
			                                        packageWeight=@packageWeight,
			                                        deliveryFee=@deliveryFee,
			                                        status=@status
		                                        WHERE
			                                        id= @id;",
                    new { parcel.invoiceNo, parcel.paymetMethod, parcel.packageWeight, parcel.deliveryFee, parcel.parcelStatus, id });
        }


        public int? deleteOne(int id)
        {
            return ConnectionDB.ExecuteQuery("DELETE FROM parcel WHERE id=@id", new { id });
        }
    }
}
