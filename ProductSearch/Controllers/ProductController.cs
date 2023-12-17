using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSearch.Data;
using ProductSearch.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

public class ProductController : Controller
{
    private readonly ProductSearchDbContext _context;

    public ProductController(ProductSearchDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        List<Product> products = _context.Products.ToList();

        return View(products);
    }
    [HttpPost]
    public IActionResult SearchProducts(
       string productName,
       string size,
       decimal? price,
       DateTime? mfgDate,
       string category)
    {
        var productNameParam = new SqlParameter("@ProductName", productName ?? (object)DBNull.Value);
        var sizeParam = new SqlParameter("@Size", size ?? (object)DBNull.Value);
        var priceParam = new SqlParameter("@Price", price ?? (object)DBNull.Value);
        var mfgDateParam = new SqlParameter("@MfgDate", mfgDate ?? (object)DBNull.Value);
        var categoryParam = new SqlParameter("@Category", category ?? (object)DBNull.Value);

        var results = _context.Products
            .FromSqlRaw("EXEC SearchProducts @ProductName, @Size, @Price, @MfgDate, @Category",
                productNameParam, sizeParam, priceParam, mfgDateParam, categoryParam)
            .ToList();

        return View("SearchResults", results);
    }
}
