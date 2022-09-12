﻿using CompanyApp.Context;
using CompanyApp.Models;
using Dapper;

namespace CompanyApp.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;

        public CompanyRepository(DapperContext context)
        {
            _context = context;
        }

        public async Company GetCompany(int id)
        {
            var query = "SELECT * FROM Companies WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefault(query, new { id });
                
                return company;
            }
        }
    }
}
