﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAO
{
    public class CustomerDAO : IDAO<Customer>
    {
        private static CustomerDAO instance = null;
        private static readonly object instanceLock = new object();
        private CustomerDAO() { }
        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }

        public void deleteData(Customer t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.Customers.Remove(t);
                dbContext.SaveChanges();
                return;
            }
        }

        public Customer getById(string id)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.Customers.Find(id);
            }
        }

        public Customer getByEmailAndPsw(string email, string password)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                try
                {
                    return dbContext.Customers.Where(c => c.CustomerEmail == email && c.CustomerPassword == password)
                    .SingleOrDefault();
                } catch (ArgumentNullException e)
                {
                    return null;
                }
                
            }
        }

        public List<Customer> getData()
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.Customers.ToList();
            }
        }

        public List<Customer> getDataWithStr(string search)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.Customers.Where(c => c.CustomerName.Contains(search)).ToList();
            }
        }

        public void insertData(Customer t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.Customers.Add(t);
                dbContext.SaveChanges();
                return;
            }
        }

        public void updateData(Customer t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.Customers.Update(t);
                dbContext.SaveChanges();
                return;
            }
        }
    }
}
