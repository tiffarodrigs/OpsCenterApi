using Microsoft.EntityFrameworkCore;
using Bogus;
using System;
//using System.Text.Json;
using System.Collections.Generic;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace OpsCenterApi.Model
{
  public class OpsCenterContext : DbContext
  {
    public OpsCenterContext(DbContextOptions<OpsCenterContext> options) : base(options)
    {    
    }
    public DbSet<OpsCenter> OpsCenters {get;set;}

    protected override void OnModelCreating(ModelBuilder builder)
    { 
        Console.WriteLine("ttttt:");
      Randomizer.Seed =new Random(Seed:34256);
      var ids = 1;
      var opsData = new Faker<OpsCenter>()
        .RuleFor(m => m.TransactionId, f => ids++)
        .RuleFor(m => m.CPUUsage, f => f.Random.Int(1,10))
        .RuleFor(m => m.ResponseTime, f => f.Random.Int(1,10))
        .RuleFor(m => m.ErrorRate, f => f.Random.Int(1,10))
        .RuleFor(m => m.RecordsProcessed, f => f.Random.Int(1,10));

   // generate 1000 items
   //builder
       // .Entity<OpsCenter>()
        //.HasData(opsData.GenerateBetween(10, 10));
       //.HasData(opsData.Generate(10));

        Console.WriteLine("opsData : "+opsData);
        var user = opsData.Generate(2);
        Console.WriteLine("user : "+user);
        Console.WriteLine("Bogus Data : "+JsonConvert.SerializeObject(user, Formatting.Indented));         
    }
  }  
    
}

