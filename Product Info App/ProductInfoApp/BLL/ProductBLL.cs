using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductInfoApp.DAL.DAO;
using ProductInfoApp.DAL.GateWay;

namespace ProductInfoApp.BLL
{
    class ProductBLL
    {
        private ProductGateWay aProductGateWay;

        public ProductBLL()
        {
            aProductGateWay = new ProductGateWay();
        }

        public string Save(Product aProduct)
        {
            string msg = "";
            if ((aProduct.Code == string.Empty || aProduct.Name == string.Empty || aProduct.Quantity==string.Empty)||!(aProduct.Code.Length == 3)||!(aProduct.Name.Length <= 10 && aProduct.Name.Length >= 5)||IsValidCode(aProduct.Code)||IsValidName(aProduct.Name))
                {
                        if (aProduct.Code == string.Empty || aProduct.Name == string.Empty)
                        {
                            msg += "Please fill up all product fields\n";
                        
                        }
                   
                        if (!(aProduct.Code.Length == 3))
                        {
                            msg += "Code Length Not valid(Must 3 character)\n";
                        }
                        if (!(aProduct.Name.Length <= 10 && aProduct.Name.Length >= 5))
                        {
                            msg += "Name Length Not valid(Must 5-10 chatacter)\n";
                        }
                        if (IsValidCode(aProduct.Code))
                        {
                            msg += "Code Already exists in Database\n";
                        }
                        if (IsValidName(aProduct.Name))
                        {
                            msg += "Name Already exists in Database\n";

                        }
                    return msg;
                }
            //else if (!(aProduct.Code.Length == 3))
            //    {
            //        msg += "Code Length Not valid\n";
            //    }
              //else if (!(aProduct.Name.Length <= 10 && aProduct.Name.Length >= 5))
              //    {
              //        msg += "Name Length Not valid\n";
              //    }                                       
          
              //else if (IsValidCode(aProduct.Code))
              //     {

              //         msg += "Code Already exists in Database\n";

              //     }
                  //else if (IsValidName(aProduct.Name))
                  // {
                  //     msg += "Name Already exists in Database\n";

                  // }
                   else
                   {
                       return aProductGateWay.Save(aProduct);
                   }                                            
          
        }

        private bool IsValidName(string name)
        {
            return aProductGateWay.IsValidName(name);
        }

        private bool IsValidCode(string code)
        {
            return aProductGateWay.IsValidCode(code);
        }

        public List<Product> GetAllProduct()
        {
           List<Product > products=new List<Product>();
            products = aProductGateWay.GetAllProduct();
            return products;
        }
    }
}
