using AutoMapper;
using QuickResponse.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL = QuickResponse.Data.Models;
namespace QuickResponse.Core
{
    public class Mapper
    {
        public static Lists MapperModels(IEnumerable<DAL.Post> postsDAL,IEnumerable<DAL.User> usersDAL,
                                             IEnumerable<DAL.Product> productsDAL,IEnumerable<DAL.Order> ordersDAL,
                                             IEnumerable<DAL.ProductType> productTypesDAL, IMapper mapper)
        {
            var lists = new Lists();
            foreach (var p in postsDAL)
            {
                var post = mapper.Map<DAL.Post, Post>(p);
                lists.postsPL.Add(post);
            }
            foreach (var u in usersDAL)
            {
                var user = mapper.Map<DAL.User, User>(u);
                lists.usersPL.Add(user);
            }
            foreach (var p in productsDAL)
            {
                var product = mapper.Map<DAL.Product, Product>(p);
                lists.productsPL.Add(product);
            }
            foreach (var t in productTypesDAL)
            {
                var productType = mapper.Map<DAL.ProductType, ProductType>(t);
                lists.productTypesPL.Add(productType);
            }
            foreach (var o in ordersDAL)
            {
                var order = mapper.Map<DAL.Order, Order>(o);
                lists.ordersPL.Add(order);
            }

            return lists;
        }
        
    }                        
}
