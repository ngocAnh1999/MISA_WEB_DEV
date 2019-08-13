using MISA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL
{
    public class CustomerDL
    {
        private MISACustomerContext db = new MISACustomerContext();

        // Hàm thực hiện lấy danh sách khách hàng
        // Người tạo: Ngọc Ánh
        // Ngày tạo: 04/08/2019
        public IEnumerable<Customer> GetCustomer ()
        {
            return db.Customers;
        }

        // Hàm thực hiện thêm khách hàng vào db
        // Người tạo: Ngọc Ánh
        // Ngày tạo: 04/08/2019
        public void AddNew (Customer _customer)
        {
            _customer.CustomerID = Guid.NewGuid();
            db.Customers.Add(_customer);
            db.SaveChanges();
        }

        // Hàm thực hiện cập nhật dữ liệu khách hàng
        // Người tạo: Ngọc Ánh
        // Ngày tạo: 04/08/2019
        public void UpdateCustomer (Customer _customer, Guid CustomerID)
        {
            Customer customer = db.Customers.Find(CustomerID);
            customer = _customer;
            db.SaveChanges();
        }

        // Hàm thực hiện xóa dữ liệu khách hàng
        // Người tạo: Ngọc Ánh
        // Ngày tạo: 04/08/2019
        public void DeleteCustomers (List<Guid> customerIDs)
        {
            foreach(var id in customerIDs)
            {
                var customer_item = db.Customers.Where(p => p.CustomerID == id).FirstOrDefault();
                db.Customers.Remove(customer_item);
                
            }
            db.SaveChanges();
        }
    }
}
