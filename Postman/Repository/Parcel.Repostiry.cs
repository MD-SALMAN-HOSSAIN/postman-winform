using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postman.Models;
using Postman.DataAccess;
namespace Postman.Repository
{
    class ParcelRepositry
    {
        public int? createone(Parcel parcel ,int customerId, int userId)
        {
            return ConnectionDB.ExecuteQuery(@"	INSERT INTO parcel VALUES
                                                (
                                                    @invoiceNo,
                                                    @method,
                                                    @packageWeight,
                                                    @amountToCollect,
                                                    @deliveryFee,
                                                    @status,  @customerId,@userId,null);",
                new { parcel.invoiceNo, parcel.paymetMethod, parcel.packageWeight, parcel.amountToCollect, parcel.deliveryFee,customerId, userId});
        }

        public List<Parcel> getAllUser(int id)
        {
            return ConnectionDB.SelectQuery<Parcel>("SELECT * FROM parcel WHERE userId=@id", new { id }).ToList();
        }


        public int? AssignParcelToRider(int id, int riderId)
        {
            return ConnectionDB.ExecuteQuery("UPDATE parcel SET riderId=@riderId WHERE id=@id", new {riderId, id });
        }


        public List<Parcel> getRiderConsignments(int riderId)
        {
            return ConnectionDB.SelectQuery<Parcel>("SELECT * FROM parcel WHERE riderId=@riderId", new { riderId }).ToList();
        }

        public List<Parcel> getAll()
        {
            return ConnectionDB.SelectQuery<Parcel>("SELECT * FROM parcel;").ToList();
        }

        public Parcel getOneParcel(int id)
        {
            return ConnectionDB.SelectQuery<Parcel>("SELECT * FROM parcel;").SingleOrDefault();
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
