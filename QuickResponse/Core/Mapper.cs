using AutoMapper;
using QuickResponse.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core
{
    public class Mapper
    {
        public static Lists MapperModels(IEnumerable<Data.Models.Post> postsDAL,IEnumerable<Data.Models.User> usersDAL,
                                             IEnumerable<Data.Models.Product> productsDAL,IEnumerable<Data.Models.Order> ordersDAL,
                                             IEnumerable<Data.Models.ProductType> productTypesDAL, IMapper mapper)
        {
            var lists = new Lists();
            foreach (var p in postsDAL)
            {
                var post = mapper.Map<Data.Models.Post, Post>(p);
                lists.postsPL.Add(post);
            }
            foreach (var u in usersDAL)
            {
                var user = mapper.Map<Data.Models.User, User>(u);
                lists.usersPL.Add(user);
            }
            foreach (var p in productsDAL)
            {
                var product = mapper.Map<Data.Models.Product, Product>(p);
                lists.productsPL.Add(product);
            }
            foreach (var t in productTypesDAL)
            {
                var productType = mapper.Map<Data.Models.ProductType, ProductType>(t);
                lists.productTypesPL.Add(productType);
            }
            foreach (var o in ordersDAL)
            {
                var order = mapper.Map<Data.Models.Order, Order>(o);
                lists.ordersPL.Add(order);
            }

            return lists;
        }
        
    }                        
}
