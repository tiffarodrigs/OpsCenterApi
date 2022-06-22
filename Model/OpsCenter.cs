using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace OpsCenterApi.Model
{
  public class OpsCenter
  {
    [Key]
    public int TransactionId { get; set;}
    public int CPUUsage { get; set;}
    public int ResponseTime { get; set;}
    public int ErrorRate { get; set;}
    public int RecordsProcessed { get; set;}
  }

}