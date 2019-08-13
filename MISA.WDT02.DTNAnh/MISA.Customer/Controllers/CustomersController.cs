using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MISA.Customers.Models;
using MISA.Entities;
using MISA.DL;
using MISA.Customers.Properties;

namespace MISA.Customers.Controllers
{
    public class CustomersController : ApiController
    {
        private CustomerDL customerDL = new CustomerDL();

        /// <summary>
        /// Hàm thực hiện lấy dữ liệu từ bảng Khách hàng
        /// Người tạo: Ngọc Ánh
        /// Ngày tạo: 04/08/2019
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
       [Route("customers")]
       [HttpGet] 
       public AjaxResult getCustomers ()
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _ajaxResult.Data = customerDL.GetCustomer();
            }catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
                _ajaxResult.Data = ex;
            }

            return _ajaxResult;
        }

        /// <summary>
        /// Hàm thực hiện thêm dữ liệu vào bảng Khách hàng
        /// Người tạo: Ngọc Ánh
        /// Ngày tạo: 04/08/2019
        /// </summary>
        [Route("customers")]
        [HttpPost]
        public AjaxResult Post([FromBody] Customer _customer)
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                customerDL.AddNew(_customer);
            }
            catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
                _ajaxResult.Data = ex;

            }
            return _ajaxResult;
        }

        ///<summary>
        /// Hàm thực hiện xóa dữ liệu trong bảng khách hàng
        /// Người tạo: Ngọc Ánh
        /// Ngày tạo: 04/08/2019
        ///</summary>
        ///<returns></returns>
        [Route("customers")]
        [HttpDelete]
        public AjaxResult deleteMulti ([FromBody] List<Guid> customerIDs)
        {

            var _ajaxResult = new AjaxResult();
            try
            {
                customerDL.DeleteCustomers(customerIDs);
                
            }
            catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
                _ajaxResult.Data = ex;

            }
            return _ajaxResult;
        }

        ///<summary>
        /// Hàm thực hiện sửa dữ liệu trong bảng khách hàng
        /// Người tạo: Ngọc Ánh
        /// Ngày tạo: 04/08/2019
        ///</summary>
        ///<returns></returns>
        [Route("customers/{CustomerID}")]
        [HttpPut]
        public AjaxResult EditData([FromBody]Customer customer, [FromUri]Guid CustomerID)
        {
            AjaxResult _ajaxResult = new AjaxResult();
            
            try
            {
                customerDL.UpdateCustomer(customer, CustomerID);

            }
            catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
                _ajaxResult.Data = ex;

            }
            return _ajaxResult;
        }
    }
}